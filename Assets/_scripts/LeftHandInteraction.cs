using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandInteraction : MonoBehaviour
{
    private SteamVR_TrackedObject controller;
    public SteamVR_Controller.Device device;
    public float throwForce = 1.5f;

    public static bool holdingBall = false;
    public Vector3 ballPos;


    // Use this for initialization
    void Start()
    {
        controller = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        device = SteamVR_Controller.Input((int)controller.index);

    }

    private void OnTriggerStay(Collider col)
    {
        //called every frame when you are touching a Rigidbody with "Ball" tag
        if (col.gameObject.CompareTag("Ball"))
        {

            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                ThrowBall(col);
                holdingBall = false;
            }
            else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                GrabBall(col);
                holdingBall = true;
                ballPos = col.gameObject.transform.position;
            }
            //Debug.Log("Collision with Ball");
        }


        if (col.gameObject.CompareTag("Throwable") || col.gameObject.CompareTag("Goal") || col.gameObject.CompareTag("Trampoline"))
        {
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                ThrowObject(col);
            }
            else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                GrabObject(col);
            }
        }
    }

    void GrabBall(Collider coli)
    {
        // make the controller its parent
        coli.transform.SetParent(gameObject.transform);
        //turn off physics
        coli.GetComponent<Rigidbody>().isKinematic = true;
        // add haptic feedback by vibrating the controller
        device.TriggerHapticPulse(2000);
        //Debug.Log("You are touching down the trigger on the ball");
    }
    void ThrowBall(Collider coli)
    {
        //unparent the controller from the object
        coli.transform.SetParent(null);
        //turn on physics
        Rigidbody rigidbody = coli.GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        //set velocity based on the controller movement
        rigidbody.velocity = device.velocity * throwForce;
        rigidbody.angularVelocity = device.angularVelocity;
        //Debug.Log("You have released the trigger");
    }
    void GrabObject(Collider coli)
    {
        coli.transform.SetParent(gameObject.transform);
        coli.GetComponent<Rigidbody>().isKinematic = true;
        device.TriggerHapticPulse(500);
        Debug.Log("Hold Object");
    }
    void ThrowObject(Collider coli)
    {
        coli.transform.SetParent(null);
        Rigidbody rigidbody = coli.GetComponent<Rigidbody>();
        rigidbody.velocity = device.velocity * 0f;
        rigidbody.angularVelocity = device.angularVelocity * 0f;
        Debug.Log("Object Spawn");
    }
}
