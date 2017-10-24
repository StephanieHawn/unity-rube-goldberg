using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleStar_4_3 : MonoBehaviour {

    public GameObject particle;
    public static bool isTouched3 = false;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            //SteamVR_LoadLevel.Begin("Level-1-");
            Instantiate(particle, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            isTouched3 = true;
            Debug.Log(isTouched3);
        }
        
    }
}
