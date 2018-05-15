using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crabbot : MonoBehaviour {

    public Transform[] path;
    public float reachDistance = 1.0f;
    public int currentPoint;
    public float speed = 1.0f;


	// Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {
        GoToPoint();
         
	}

    void GoToPoint()
    {
        Vector3 dir = path[currentPoint].position - transform.position;
        transform.position += dir * Time.deltaTime * speed;
        if (dir.magnitude <= reachDistance)
        {
            currentPoint++;
        }

        if (currentPoint >= path.Length)
        {
            currentPoint = 0;
        }
    }

    void OnDrawGizmos()
    {
        if (path.Length > 0)
        {
            for(int i = 0; i < path.Length; i++)
            {
                if(path[i] != null)
                {
                    Gizmos.DrawSphere(path[i].position, reachDistance);
                }
            }
        }   
    }

}
