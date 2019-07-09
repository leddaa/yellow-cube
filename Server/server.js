export default (request) => { 
    const db = require('kvstore');
    const pubnub = require('pubnub');
    
    var message = JSON.parse(request.message);
    
    console.log("Message received: ", message);
    
    let { usr: username, lvl: level } = message;
    let score = parseInt(message.scr);
    
    var storeChanged = false;
    
    var store = null;
    db.get("levels").then((data) => {
        if(!data) { // Init store
            console.log("Initializing db");
            store = {};
        } else { // Use saved store
            store = data;
        }
        
        console.log("Current db:", store);
        
        // Init level if it doesn't exist
        if(!store[level]) {
            initLevel(store, level);
            storeChanged = true;
        }
        
        var userIndex = getUserIndex(store, level, username);
        
        var checkScore = true;
        
        if(userIndex != -1) { // Player already exists
            if(parseInt(score) < parseInt(store[level].scores[userIndex])) { // New score is better than previous score
                removeEntry(store, level, userIndex);
                addDummyEntry(store, level, 4);
                
                storeChanged = true;
            } else {
                checkScore = false;
            }
        }
        
        if(checkScore) {
            let i = 0;
            
            store[level].scores.some(item => {
                if(parseInt(score) < parseInt(item)) {
                    store[level].scores = updateList(score, store[level].scores, i);
                    store[level].usernames = updateList(username, store[level].usernames, i);
                    
                    storeChanged = true;
                    
                    return true;
                }
                i++;
            });
        }
        
        if(storeChanged) {
            writeToDatabase(db, store);
        }
        
        publish(store, pubnub);
    });
    
    return request.ok(); // Return a promise when you're done 
};

// Remove entry at index
function removeEntry(store, level, index) {
    store[level].scores.splice(index, 1);
    store[level].usernames.splice(index, 1);
}

// Add dummy entry at index
function addDummyEntry(store, level, index) {
    store[level].scores.splice(index, 0, "-");
    store[level].usernames.splice(index, 0, "-");
}

// Returns user index at level
function getUserIndex(store, level, username) {
    return store[level].usernames.findIndex(item => {
            return item == username;
    });
}

// Init new level
function initLevel(store, level) {
    console.log("Initializing level ", level);
    
    store[level] = {};
    store[level].usernames = ["-", "-", "-", "-", "-"];
    store[level].scores = [100000000, 100000000, 100000000, 100000000, 100000000]
}

// Write to store
function writeToDatabase(db, store) {
    console.log("Writing to db: ", store)
    db.set("levels", store);
}

// Publish store
function publish(store, pubnub) {
    pubnub.publish({
                    "channel": "my_channel2",
                    "message": store
                }).then((publishResponse) => {
                    console.log("Publish reponse: ", publishResponse);
                });
}

// Update list with an item
function updateList(item, list, index) {
    var listHead = [];
    var listTail = [];
    
    listHead = list.slice(0, index);
    listTail = list.slice(index, list.length);
    
    listHead.push(item);
    
    var updatedList = listHead.concat(listTail);
    updatedList.splice(-1, 1);
    
    return updatedList;
}