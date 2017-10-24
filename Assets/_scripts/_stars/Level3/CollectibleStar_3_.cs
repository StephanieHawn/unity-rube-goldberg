using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleStar_3_ : MonoBehaviour {

    public GameObject particle;
    public static bool isTouched = false ;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            //SteamVR_LoadLevel.Begin("Level-1-");
            Instantiate(particle, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            isTouched = true;
            Debug.Log(isTouched);
        }
        
    }
}
