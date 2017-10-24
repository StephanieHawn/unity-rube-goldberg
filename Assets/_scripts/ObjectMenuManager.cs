using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMenuManager : MonoBehaviour
{

    public List<GameObject> objectList; // Handled Automatically at start 
    public List<GameObject> objectPrefabList; // Set manually in inspector and MUST match order of scene menu objects
    public int currentObject = 0;

    public Vector3 trampolinePosition;

    // Use this for initialization
    void Start()
    {
        foreach (Transform child in transform)
        {
            objectList.Add(child.gameObject);
        }

    }
    public void Menuforwards()
    {
        objectList[currentObject].SetActive(false);
        currentObject++;
        if (currentObject > objectList.Count - 1)
        {
            currentObject = 0;
        }
        objectList[currentObject].SetActive(true);
    }
    public void Menubackwards()
    {
        objectList[currentObject].SetActive(false);
        currentObject--;
        if (currentObject < 0)
        {
            currentObject = objectList.Count - 1;
        }
        objectList[currentObject].SetActive(true);
    }
    public void SpawnCurrentObject()
    {
        Instantiate(objectPrefabList[currentObject], objectPrefabList[currentObject].transform.position, objectPrefabList[currentObject].transform.rotation);

        if (objectPrefabList[currentObject].gameObject.CompareTag("Trampoline"))
        {
            trampolinePosition = objectPrefabList[currentObject].transform.position;
        }

    }
    public void DestroyObject()
    {
        objectList[currentObject].SetActive(false);
    }

}