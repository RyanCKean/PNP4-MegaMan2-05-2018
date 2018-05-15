using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*--------------------------------------------------------------
 * Name: Nathan Geno
 * Date: 1/17/18
 * Credit: Project and Portfolio 4 - MegaMan 2 group project
 * Purpose: Create a "Mole" type enemy
 * ------------------------------------------------------------*/

public class MoleStateMachine : MonoBehaviour
{
    [SerializeField] private bool movingUp = true;
    [SerializeField] private GameObject targetDestination;
    [SerializeField] private GameObject destination;
    [SerializeField] Transform Up;

    //StateMachine Setup ---------------------------------------------------------------------
    private EnemyData enemyData;

    Dictionary<MoleStates, Action> msm = new Dictionary<MoleStates, Action>();

    enum MoleStates
    {
        ALIVE,
        DEAD
    }

    private MoleStates currentState = MoleStates.ALIVE;

    void SetState(MoleStates newState)
    {
        currentState = newState;
    }

    // Use this for initialization
    void Start()
    {
        enemyData = GetComponent<EnemyData>();

        enemyData.Health = UnityEngine.Random.Range(6, 10);
        enemyData.MoveSpeed = 3;
        enemyData.PhysicalDamage = 3;

        if (transform.position.y < enemyData.MainCam.transform.position.y)
            movingUp = true;
        if (transform.position.y > enemyData.MainCam.transform.position.y)
            movingUp = false;


        msm.Add(MoleStates.ALIVE, new Action(AliveState));
        msm.Add(MoleStates.DEAD, new Action(DeadState));
    }

    // Update is called once per frame
    void Update()
    {
        float step = enemyData.MoveSpeed * Time.deltaTime;

        msm[currentState].Invoke();
    }

    void MoveUp()
    {
        movingUp = true;
        enemyData.Rb.AddForce(transform.up * enemyData.MoveSpeed);
    }

    void MoveDown()
    {
        movingUp = false;
        enemyData.Rb.AddForce(transform.up * -enemyData.MoveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bullet")
        {
            enemyData.Health--;
        }

        if (collision.gameObject.tag == "Environment");
        {
            //gameObject.GetComponent<Collider2D>().isTrigger = true;
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
            enemyData.MoveSpeed = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Environment")
        {
            enemyData.MoveSpeed = 3;
        }
    }

    //States -----------------------------------------------------------------------------
    void AliveState()
    {
        if (movingUp)
        {
            MoveUp();
        }

        else
        {
            MoveDown();
        }
            

        if (enemyData.DistanceToCamX >= 16 || enemyData.DistanceToCamX <= -16)
        {
            SetState(MoleStates.DEAD);
        }

        if(enemyData.Health == 0)
        {
            SetState(MoleStates.DEAD);
        }
    }

    void DeadState()
    {
        GameObject.Destroy(gameObject);
    }
}
