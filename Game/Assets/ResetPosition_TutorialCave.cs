﻿using Org.BouncyCastle.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetPosition_TutorialCave : MonoBehaviour
{


    public Vector3 PlayerPosition;


    private void OnTriggerStay(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            var playerSize = player.transform.localScale;
            Debug.Log(playerSize);

            if (playerSize.x != 0.5)
            {
                Debug.Log("Reset player position");
                player.transform.localPosition = PlayerPosition;
                
            }
        }
    }

  
}
