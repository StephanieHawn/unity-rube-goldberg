﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallScript_3_ : MonoBehaviour {
    public static bool winState = false;
    //public SteamVR_LoadLevel loadLevel
    public GameObject ballInstantiate;
    public GameObject collectible;
    public GameObject collectible1;
    public GameObject resetBall;

    public AudioSource ground;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            ground.Play();
            gameObject.transform.position = ballInstantiate.transform.position;
            //Destroy(gameObject);
            //Instantiate(resetBall, ballInstantiate.transform.position, Quaternion.identity);
            collectible.SetActive(true);
            collectible1.SetActive(true);
        }
        if (col.gameObject.CompareTag("Goal"))
        {
            if (CollectibleStar_3_.isTouched && CollectibleStar_3_1.isTouched1)
            {
                winState = true;
                Debug.Log(winState);
            }
            if (winState)
            {
                Destroy(gameObject);
                SteamVR_LoadLevel.Begin("Level4");
                winState = false;
            }
            else
            {
                Destroy(gameObject);
                gameObject.transform.position = ballInstantiate.transform.position;
                //Instantiate(resetBall, ballInstantiate.transform.position, Quaternion.identity);
                collectible.SetActive(true);
                //SteamVR_LoadLevel.Begin("Level3");
                winState = false;
            }
        }
    }
}
