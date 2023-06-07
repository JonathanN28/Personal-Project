using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
  public GameObject movePositionTransform;
  public GameObject currentTarget;
  private NavMeshAgent navMeshAgent;
  public int range;
  public int tetherRange;
  public Vector3 startPos;
  private void Awake()
  {
    navMeshAgent = GetComponent<NavMeshAgent>();
    InvokeRepeating("DistCheck", 0, 0.001f);
    startPos = this.transform.position;
  }

  private void Update()
  {
    if (currentTarget != null)
    {
      navMeshAgent.destination = currentTarget.transform.position;
    }
    else if (navMeshAgent.destination != startPos)
    {
      navMeshAgent.destination = startPos;
    }
  }

  public void DistCheck()
  {
    float dist = Vector3.Distance(this.transform.position, movePositionTransform.transform.position);
    // Basic following (direct), navMeshAgent.destination = movePositionTransform.position;

    if (dist < range)
    {
      navMeshAgent.destination = movePositionTransform.transform.position;
    }
    else if (dist < tetherRange)
    {
      currentTarget = null;
    }
  }
}
