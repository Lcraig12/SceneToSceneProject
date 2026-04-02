using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class ThirdSceneEnemy : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;


    void Start () {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

    }


    void Update () {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }
}
