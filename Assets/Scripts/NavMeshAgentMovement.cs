using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NavMeshAgentMovement : MonoBehaviour
{
    public GameObject ply;
    private float plyDistFromAgent;
    
    public NavMeshAgent Agent;
    private float waypointRemainingDist;
    
    public Transform[] wayPoints;
    private int wayPointLocator = 0;

    public AudioClip chaseSound;
    private AudioSource teacherAudio;

    void Start()
    {
        teacherAudio = GetComponent<AudioSource>();
        Agent = GetComponent<NavMeshAgent>();
        GotoNextPoint();
    }

    private void GotoNextPoint()
    {
        if (wayPointLocator >= wayPoints.Length - 1)
        {
            wayPointLocator = 0;
        }
        wayPointLocator = wayPointLocator + 1;
        Agent.destination = wayPoints[wayPointLocator].position;
    }

    private void DetectPlayer()
    {
        Agent.destination = ply.transform.position;
    }

    void Update()
    {
        plyDistFromAgent = Vector3.Distance(ply.transform.position, Agent.transform.position);
        waypointRemainingDist = Vector3.Distance(Agent.transform.position, wayPoints[wayPointLocator].position);
        
        if (ply.GetComponent<PlayerMovement>().Hiding == true)
        {
            Agent.destination = wayPoints[wayPointLocator].position;
            CancelInvoke("increaseSpeed");
            Agent.speed = 3.5f;
        }
        else
        {
            if (plyDistFromAgent <= 6)
            {
                DetectPlayer();
            }
            else
            {
                if (plyDistFromAgent > 10)
                {
                    Agent.destination = wayPoints[wayPointLocator].position;
                    CancelInvoke("increaseSpeed");
                    Agent.speed = 3.5f;
                }
                else
                {
                    if (Agent.speed == 3.5f)
                    {
                        InvokeRepeating("increaseSpeed", 0, 1);
                    }
                    DetectPlayer();
                }
            }

        }
        if (waypointRemainingDist <= 1) 
        {
            GotoNextPoint();
        }
    }

    private void increaseSpeed()
    {
        Agent.speed = Agent.speed + 0.5f;
    }
}
