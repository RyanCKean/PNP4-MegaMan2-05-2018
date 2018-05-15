using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*--------------------------------------------------------------
 * Name: Nathan Geno
 * Date: 1/15/18
 * Credit: Project and Portfolio 4 - MegaMan 2 group project
 * Purpose: Create a data holder for a Character Spawner State Machine
 * ------------------------------------------------------------*/

public class CharacterSpawner : MonoBehaviour
{
    //Variables
    [SerializeField] GameObject character;
    [SerializeField] Camera mainCam;
    [SerializeField] bool cameraCanSee = false;

    private float spawnDistance;
    
    //Accessors
    public bool CameraCanSee
    {
        get {return cameraCanSee;}

        set {cameraCanSee = value;}
    }
    
    public GameObject Character
    {
        get { return character; }

        set { character = value; }
    }

    public Camera MainCamera
    {
        get { return mainCam; }

        set { mainCam = value; }
    }

    public float SpawnDistance
    {
        get { return spawnDistance; }

        set { spawnDistance = value; }
    }

    // Use this for initialization
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log(spawnDistance);
    }

}
