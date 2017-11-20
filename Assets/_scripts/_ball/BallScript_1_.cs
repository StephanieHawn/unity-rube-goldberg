using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallScript_1_ : MonoBehaviour {
    public static bool winState = false;
    //public SteamVR_LoadLevel loadLevel
    //public RightHandInteraction ballInstantiate;
    public GameObject ballInstantiate;
    public GameObject collectible;
    public GameObject collectible1;
    public GameObject resetBall;

    public AudioSource ground;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            ground.Play();
            gameObject.transform.position = ballInstantiate.transform.position;
            //Destroy(gameObject);
            //Instantiate(resetBall, ballInstantiate.transform.position, Quaternion.identity);
            //Instantiate(resetBall, ballInstantiate.ballPos, Quaternion.identity);
            collectible.SetActive(true);
            collectible1.SetActive(true);
        }
        if (col.gameObject.CompareTag("Goal"))
        {
            if (CollectibleStar_1.isTouched && CollectibleStar1_1.isTouched1)
            {
                winState = true;
                Debug.Log(winState);
            }
            if (winState)
            {
                Destroy(gameObject);
                SteamVR_LoadLevel.Begin("Level2");
                winState = false;
                
            }
            else
            {
                //Destroy(gameObject);
                //Instantiate(resetBall, ballInstantiate.transform.position, Quaternion.identity);
                gameObject.transform.position = ballInstantiate.transform.position;
                collectible.SetActive(true);
                //SteamVR_LoadLevel.Begin("Level1");
                winState = false;
            }
        }
    }
}
