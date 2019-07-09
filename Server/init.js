export default (request) => { 
    const db = require('kvstore');
    const pubnub = require('pubnub');
    
    var message = JSON.parse(JSON.stringify(request.message));
    
    console.log("Message received: ", message);
    db.set("levels", {});

    
    return request.ok(); // Return a promise when you're done 
};
