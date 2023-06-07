using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject pivot;

    // private Vector3 offset = new Vector3(0, 3, -5);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = pivot.transform.position;
        transform.rotation = pivot.transform.rotation;
    }
    // prob make adjusting pivot against wall
}
