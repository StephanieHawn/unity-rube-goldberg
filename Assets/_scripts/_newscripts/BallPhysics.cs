﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour {

    //public handInteraction handinteractionL;
    //public handInteraction handinteractionR;
    public RightHandInteraction holdingBall;
    public Material glowMat;
    //public GameObject destroyPoofObject;
    public GameObject lastHitObject;

    public Material skyboxLight;
    public Material skyboxDark;
    public AudioClip ballClip;

    //public AudioSource[] sources;
    
    public GameObject controllerL;
    public GameObject controllerR;

    private LayerMask Interactive;

    public float initXPos;
    public float initYPos;
    public float initZPos;

    public float xposGround;
    public float yposGround;
    public float zposGround;

    public bool inPlayArea = true;

    public Material mat1;
    public Material mat2;

    private float curveWidth = .025f;
 





    // Use this for initialization
    void Start() {

        initXPos = gameObject.transform.position.x;
        initYPos = gameObject.transform.position.y;
        initZPos = gameObject.transform.position.z;





    }

    // Update is called once per frame
    void Update() {

        /*
        //check Left controller grabbing status
        if (RightHandInteraction.holdingBall)
          { 
            if(controllerL.transform.position.x < 1 && controllerL.transform.position.x > -1
            && controllerL.transform.position.z < 1 && controllerL.transform.position.z > -1)
            {
                Debug.Log("you are in the playing feild");
                GetComponent<Renderer>().material = mat2;
                GetComponent<Rigidbody>().mass = 1;
                GetComponent<Rigidbody>().drag = 0;
                notCheater();
            }                         
        }

        if (RightHandInteraction.holdingBall)
        {
            if(controllerL.transform.position.x > 1 || controllerL.transform.position.x < -1
             || controllerL.transform.position.z > 1 || controllerL.transform.position.z < -1)
            {
                Debug.Log("you are out of bounds holding the ball...you could be cheating......");                
                Cheater();
            }             
            
        }*/

        
        //check Left controller grabbing status
        if (RightHandInteraction.holdingBall == true)
        {
            if (controllerR.transform.position.x < 1 && controllerR.transform.position.x > -1 &&
             controllerR.transform.position.z < 1 && controllerR.transform.position.z > -1)
            {
                Debug.Log("you are out of bounds and grabbing something");
                GetComponent<Renderer>().material = mat2;
                GetComponent<Rigidbody>().mass = 1;
                GetComponent<Rigidbody>().drag = 0;
                notCheater();
            }
        }

        if (RightHandInteraction.holdingBall == true)
        {
            if (controllerR.transform.position.x > 1 || controllerR.transform.position.x < -1 ||
             controllerR.transform.position.z > 1 || controllerR.transform.position.z < -1)
            {
                Debug.Log("you are  out of bounds and grabbing something");
                Cheater();

               
            }
        }
        
    }

    void OnCollisionEnter(Collision col)
    {
        //reset ball position
        if (col.gameObject.CompareTag("Ground"))
        {
            xposGround = gameObject.transform.position.x;
            yposGround = gameObject.transform.position.y;
            zposGround = gameObject.transform.position.z;
            //poofHit();
            //makeLastHit();
            //sources[3].Play();
            Destroy(GetComponent<TrailRenderer>());
            Destroy(GetComponent<Light>());                
            gameObject.transform.position = new Vector3(initXPos, initYPos, initZPos);          
            Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
            rigidBody.velocity = rigidBody.velocity * 0;
            rigidBody.angularVelocity = rigidBody.angularVelocity * 0;
            GetComponent<Renderer>().material = mat2;
            GetComponent<Rigidbody>().mass = 1;
            GetComponent<Rigidbody>().drag = 0;
        }

        //bounceballSound
        /*
        if (col.gameObject.CompareTag("Untagged"))
        {

            sources[0].Play();

        }

        if (col.gameObject.CompareTag("Structure"))
        {

            gameObject.AddComponent<TrailRenderer>();
            TrailRenderer trail = GetComponent<TrailRenderer>();
            trail.material = glowMat;
            trail.startWidth = curveWidth;
            trail.receiveShadows = false;
            trail.time = 2;                    

        }
        */
    }

    /*
    public void makeLastHit()
    {
        lastHitObject.transform.position = new Vector3(xposGround, 0, zposGround);
        Debug.Log(" ball position @ explode = " + "xpos" +  xposGround + "ypos" + yposGround + "zpos" + zposGround);

    }

    public void deleteLastHit()
    {
        GameObject[] dels;
        dels = GameObject.FindGameObjectsWithTag("LastHit");
        for (int i = 0; i < dels.Length; i++)
        {
            Destroy(dels[i]);
        }        
    }
    */

    /*
public void poofHit()
{
    StartCoroutine(destroyPoof());
}

IEnumerator destroyPoof()
{
    Object.Instantiate(destroyPoofObject, new Vector3(xposGround, yposGround, zposGround), Quaternion.identity);
    yield return new WaitForSeconds(1f);
    GameObject poofToDestroy = GameObject.Find("destroyPoof(Clone)");
    Destroy(poofToDestroy);
}
*/

    public void Cheater()
    {

        Collider col = gameObject.GetComponent<Collider>();
        col.enabled = false;
        RenderSettings.fogDensity = .25f;
        RenderSettings.skybox = skyboxDark;
       

    }

    public void notCheater()
    {

        Collider col = gameObject.GetComponent<Collider>();
        col.enabled = true;        
        RenderSettings.fogDensity = .025f;
        RenderSettings.skybox = skyboxLight;

    }

}
