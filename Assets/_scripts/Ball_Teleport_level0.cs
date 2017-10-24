using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Teleport_level0 : MonoBehaviour {

    public GameObject trampoline;
    
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            Debug.Log("ball tele");
            //col.transform.position = trampoline.transform.position;
            col.transform.position = trampoline.transform.position + new Vector3(0, -1, 0);

        }
    }
}
