﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Teleport : MonoBehaviour {

    public ObjectMenuManager trampoline;
    
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            Debug.Log("ball tele");
            col.transform.position = trampoline.trampolinePosition + new Vector3(0, 1, 0);
            
        }
    }
}
