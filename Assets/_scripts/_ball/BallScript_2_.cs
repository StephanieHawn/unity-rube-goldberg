﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallScript_2_ : MonoBehaviour {
    public static bool winState = false;
    //public SteamVR_LoadLevel loadLevel
    public RightHandInteraction ballInstantiate;
    public GameObject collectible;
    public GameObject collectible1;
    public GameObject resetBall;
    
    

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            Instantiate(resetBall, ballInstantiate.ballPos, Quaternion.identity);
            collectible.SetActive(true);
            collectible1.SetActive(true);
        }
        if (col.gameObject.CompareTag("Goal"))
        {
            if (CollectibleStar_2_.isTouched && CollectibleStar_2_1.isTouched1)
            {
                winState = true;
                Debug.Log(winState);
            }
            if (winState)
            {
                Destroy(gameObject);
                SteamVR_LoadLevel.Begin("Level3");
                winState = false;

                
            }
            else
            {
                Destroy(gameObject);
                SteamVR_LoadLevel.Begin("Level2");
                winState = false;
            }
        }
    }
}