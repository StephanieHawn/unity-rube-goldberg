﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleStar1_2 : MonoBehaviour {

    public GameObject particle;
    public static bool isTouched1 = false ;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            //SteamVR_LoadLevel.Begin("Level1");
            Instantiate(particle, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            isTouched1 = true;
            Debug.Log(isTouched1);
        }
    }
    
}