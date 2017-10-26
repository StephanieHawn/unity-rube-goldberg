using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallScript_0 : MonoBehaviour {
    public static bool winState = false;
    //public SteamVR_LoadLevel loadLevel
    //public RightHandInteraction ballInstantiate;
    public GameObject ballInstantiate;
    public GameObject collectible;
    public GameObject resetBall;

    public AudioSource ground;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            ground.Play();
            Destroy(gameObject);
            Instantiate(resetBall, ballInstantiate.transform.position, Quaternion.identity);
            //Instantiate(resetBall, ballInstantiate.ballPos, Quaternion.identity);
            collectible.SetActive(true);
        }
        if (col.gameObject.CompareTag("Goal"))
        {
            if (CollectibleStar0.isTouched)
            {
                winState = true;
                Debug.Log(winState);
            }
            if (winState)
            {
                Destroy(gameObject);
                SteamVR_LoadLevel.Begin("Level1");
                winState = false;
                
            }
            else
            {
                Destroy(gameObject);
                SteamVR_LoadLevel.Begin("Level0");
                winState = false;
            }
        }
    }
}
