using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation_left : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

    //Teleporter
    private LineRenderer laser;
    public GameObject teleportAimerObject;
    public Vector3 teleportLocation;
    public GameObject player;
    public LayerMask laserMask;
    public float yNudgeAmount = 1f; //specific to teleportAimerObject height
    public float moveDistance = 5f;
    public GameObject Ball;
    public Material ballMat;


    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        laser = GetComponentInChildren<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        /*
        if (RightHandInteraction.holdingBall && device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Ball.GetComponent<Renderer>().material.color = Color.red;
        }
        */

        /*
        if(!RightHandInteraction.holdingBall)
        {*/
            //Ball.GetComponent<Renderer>().material = ballMat;
            if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                laser.gameObject.SetActive(true);
                teleportAimerObject.SetActive(true);

                //sets the start point of our linerenderer to the position of our controller since...
                //this script is attached to the controller_right object
                laser.SetPosition(0, gameObject.transform.position);


                //
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, moveDistance, laserMask))
                {
                    //gives us the Vector3 of exact position our ray collided with another object (i.e. records where the laser hits)
                    teleportLocation = hit.point;
                    //set the end point of the line renderer (or laser) to the Raycast hit point
                    laser.SetPosition(1, teleportLocation);

                    //aimer position
                    teleportAimerObject.transform.position = new Vector3(teleportLocation.x, teleportLocation.y + yNudgeAmount, teleportLocation.z);
                }
                else
                {
                    teleportLocation = new Vector3(transform.forward.x * moveDistance + transform.position.x, transform.forward.y * moveDistance + transform.position.y, transform.forward.z * moveDistance + transform.position.z);
                    //above is the same as: teleportLocation = transform.position + transform.forward * moveDistance;
                    RaycastHit groundRay;
                    if (Physics.Raycast(teleportLocation, -Vector3.up, out groundRay, 17, laserMask))
                    {
                        //if we hit the ground, teleport there
                        teleportLocation = new Vector3(transform.forward.x * moveDistance + transform.position.x, groundRay.point.y, transform.forward.z * moveDistance + transform.position.z);
                    }
                    //laser position
                    laser.SetPosition(1, transform.forward * moveDistance + transform.position);

                    //aimer position
                    teleportAimerObject.transform.position = teleportLocation + new Vector3(0, yNudgeAmount, 0);
                }
            }
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                laser.gameObject.SetActive(false);
                teleportAimerObject.SetActive(false);

                //only move player when trigger is released

                //move instantly
                player.transform.position = teleportLocation;
            }
            /*
            if (teleportLocation.z > .07 || teleportLocation.x > 2.50)
            {
                Ball.SetActive(false);
            }
            */
        //}
    }


}