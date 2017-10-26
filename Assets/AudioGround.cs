using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGround : MonoBehaviour {

    public AudioSource ground;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            ground.Play();
        }
    }
}
