﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRun : MonoBehaviour {

    public AudioSource clip;

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
            clip.Play();
        }
    }
}