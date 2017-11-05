using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {
   

    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag("Ball"))
        {
            Debug.Log("trampoline collision");
            col.gameObject.GetComponent<Rigidbody>().AddForce(0, 5, 0, ForceMode.Impulse);
        }
        
    }
}
