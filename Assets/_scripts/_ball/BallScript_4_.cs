using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallScript_4_ : MonoBehaviour {
    public static bool winState = false;
    //public SteamVR_LoadLevel loadLevel
    public GameObject ballInstantiate;
    public GameObject collectible;
    public GameObject collectible1;
    public GameObject collectible2;
    //public GameObject collectible3;
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
            collectible2.SetActive(true);
            //collectible3.SetActive(true);
        }
        if (col.gameObject.CompareTag("Goal"))
        {
            //(CollectibleStar_4_.isTouched && CollectibleStar_4_1.isTouched1 && CollectibleStar_4_2.isTouched2 && CollectibleStar_4_3.isTouched3)
            if (CollectibleStar_4_.isTouched && CollectibleStar_4_1.isTouched1 && CollectibleStar_4_2.isTouched2)
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
                gameObject.transform.position = ballInstantiate.transform.position;
                //Instantiate(resetBall, ballInstantiate.transform.position, Quaternion.identity);
                collectible.SetActive(true);
                //SteamVR_LoadLevel.Begin("Level4");
                winState = false;
                Debug.Log("Restart");
            }
        }
    }
}
