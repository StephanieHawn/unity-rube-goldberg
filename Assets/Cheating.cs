using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheating : MonoBehaviour {

    public GameObject ball;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("MainCamera"))
        {
            Debug.Log("ball enter");
            //make ball collider active
            Collider col = ball.GetComponent<SphereCollider>();
            col.enabled = true;
        }     
    }

    public void OnTriggerExit(Collider other)
    {
       // Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("MainCamera"))
        {
            //make ball collider false
            Debug.Log("ball exit");
            Collider col = ball.GetComponent<SphereCollider>();
            col.enabled = false;

        }
    }

    /*

    private void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name + "enter");
        if (col.gameObject.CompareTag("MainCamera"))
        {
            Debug.Log("ball enter");
            //make ball collider active
            Collider coli = ball.GetComponent<SphereCollider>();
            coli.enabled = true;
        }

    }

    void OnCollisionExit(Collision col)
    {
        Debug.Log(col.gameObject.name + "exit");
        if (col.gameObject.CompareTag("MainCamera"))
        {
            //make ball collider false
            Debug.Log("ball exit");
            Collider coli = ball.GetComponent<SphereCollider>();
            coli.enabled = false;
        }
    }

    */
}
