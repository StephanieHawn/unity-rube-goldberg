using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {

    public int air = 30;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            Debug.Log("fan collision");
            col.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * air);
        }

    }

    /*
    //if using trigger
    private void OnTriggerStay(Collider other)
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        if (rigidbody != null) {
            rigidbody.AddForce(transform.forward * air);
        }
        
    }
    */
}
