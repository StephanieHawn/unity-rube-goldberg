using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleStar0 : MonoBehaviour {

    public GameObject particle;
    public static bool isTouched = false ;


    private void Update()
    {
        gameObject.transform.Rotate(0, 90 * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            //SteamVR_LoadLevel.Begin("Level1");
            Instantiate(particle, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            isTouched = true;
            Debug.Log(isTouched);
        }
    }
    
}
