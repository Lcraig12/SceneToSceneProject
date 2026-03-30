using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Move_DungeonEnemy02 : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;


    void Start () {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;


        points = new Transform[4];
        //assigns points by making empty gameobjects that will set the locations
        GameObject p1 = new GameObject("p1");
        p1.transform.position = new Vector3(-13, 4, 96);
        points[0] = p1.transform;

        GameObject p2 = new GameObject("p2");
        p2.transform.position = new Vector3(-13, 4, 56);
        points[1] = p2.transform;

        GameObject p3 = new GameObject("p3");
        p3.transform.position = new Vector3(-40, 4, 56);
        points[2] = p3.transform;

        GameObject p4 = new GameObject("p4");
        p4.transform.position = new Vector3(-13, 4, 56);
        points[3] = p4.transform;
        
        


        GotoNextPoint();
    }


    void GotoNextPoint() {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update () {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
