using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandInteraction : MonoBehaviour
{
    private SteamVR_TrackedObject controller;
    public SteamVR_Controller.Device device;
    public float throwForce = 1.5f;


    public static bool holdingBall = false;
    public Vector3 ballPos;

    //Swipe
    private float swipeSum_x;
    private float touchLast_x;
    private float touchLast_y;
    private float touchCurrent_x;
    private float distance_x;
    private bool hasSwipedLeft;
    private bool hasSwipedRight;
    public ObjectMenuManager objectMenuManager;
    public GameObject objMenu;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        device = SteamVR_Controller.Input((int)controller.index);
        
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            //load new scene
            //SteamVR_LoadLevel.Begin("Teleport");

            //reset position of finger to 0, 0 (I think)
            touchLast_x = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
            touchLast_y = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y;
        }

        //detect when our user is toucing the touchpad
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            objMenu.SetActive(true);

            touchCurrent_x = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
            //how much did the finger move this frame?
            distance_x = touchCurrent_x - touchLast_x;
            //cache our fingers location so we know where it was last frame
            touchLast_x = touchCurrent_x;
            //add the distance travelled to the swipeSum variable
            swipeSum_x += distance_x;
            if (!hasSwipedRight)
            {
                if (swipeSum_x > 0.5f)
                {
                    swipeSum_x = 0;
                    SwipeLeft();
                    hasSwipedRight = true;
                    hasSwipedLeft = false;
                }
            }

            if (!hasSwipedLeft)
            {
                if (swipeSum_x < -0.5f)
                {
                    swipeSum_x = 0;
                    SwipeRight();
                    hasSwipedLeft = true;
                    hasSwipedRight = false;
                }
            }

        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            objMenu.SetActive(false);

            swipeSum_x = 0;
            touchCurrent_x = 0;
            touchLast_x = 0;
            hasSwipedLeft = false;
            hasSwipedRight = false;
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            //spawn object currently selected by menu
            SpawnObject();

            //objectMenuManager.SpawnCurrentObject();
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            objectMenuManager.DestroyObject();
        }


    }

    void SpawnObject()
    {
        objectMenuManager.SpawnCurrentObject();
    }

    void SwipeLeft()
    {
        objectMenuManager.Menuforwards();
        //Debug.Log("Swiped Left");
    }
    void SwipeRight()
    {
        objectMenuManager.Menubackwards();
        //Debug.Log("Swiped Right");
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
            //Debug.Log("Collision occurred_Ball");
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
        Debug.Log("Holding the Object");
    }
    void ThrowObject(Collider coli)
    {
        coli.transform.SetParent(null);
        Rigidbody rigidbody = coli.GetComponent<Rigidbody>();
        rigidbody.velocity = device.velocity * 0f;
        rigidbody.angularVelocity = device.angularVelocity * 0f;
        Debug.Log("Your Object Spawns");
    }
}
