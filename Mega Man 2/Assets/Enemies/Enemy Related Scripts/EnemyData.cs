using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*--------------------------------------------------------------
 * Name: Nathan Geno
 * Date: 1/17/18
 * Credit: Project and Portfolio 4 - MegaMan 2 group project
 * Purpose: Create a default data holder for all Enemy prefabs
 * ------------------------------------------------------------*/

public class EnemyData : MonoBehaviour
{
    //Variables
    [SerializeField] public int physicalDamage;
    [SerializeField] int currentHealth;
    [SerializeField] float moveSpeed;
    [SerializeField] Transform target;

    [SerializeField] Camera mainCam;
    [SerializeField] bool cameraCanSee = false;

    private Animator animator;
    private float distanceToCamX;
    private float distanceToCamY;
    private Rigidbody2D rb;

    //Accessors
    public int PhysicalDamage
    {
        get { return physicalDamage; }

        set{physicalDamage = value;}
    }

    public int Health
    {
        get { return currentHealth; }

        set { currentHealth = value; }
    }

    public Transform Target
    {
        get { return target; }

        set { target = value; }
    }

    public Camera MainCam
    {
        get { return mainCam; }

        set { mainCam = value; }
    }

    public bool CameraCanSee
    {
        get { return cameraCanSee; }

        set { cameraCanSee = value; }
    }

    public Animator Animator
    {
        get { return animator; }

        set { animator = value; }
    }

    public float MoveSpeed
    {
        get { return moveSpeed; }

        set { moveSpeed = value; }
    }

    public float DistanceToCamX
    {
        get { return distanceToCamX; }

        set { distanceToCamX = value; }
    }

    public float DistanceToCamY
    {
        get { return distanceToCamY; }

        set { distanceToCamY = value; }
    }

    public void Damage(int dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    public Rigidbody2D Rb
    {
        get { return rb; }

        set { rb = value; }
    }

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToCamX = mainCam.transform.position.x - gameObject.transform.position.x;
        distanceToCamY = mainCam.transform.position.y - gameObject.transform.position.y;
    }
}
