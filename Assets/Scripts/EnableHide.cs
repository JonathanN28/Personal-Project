using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class EnableHide : MonoBehaviour
{
    public Text hide;

    public GameObject ply;

    public Vector3 plyStartPos;

    public float plyOriginSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hide.enabled = true;  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hide.enabled = false;
        }
    }

    public void Hide()
    {
        plyOriginSpeed = ply.GetComponent<PlayerMovement>().speed;
        plyStartPos = ply.transform.position;
        ply.GetComponent<PlayerMovement>().speed = 0;
        ply.GetComponent<PlayerMovement>().Hiding = true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        ply.transform.position = gameObject.transform.position;
    }

    public void UnHide()
    {
        ply.transform.position = plyStartPos;
        ply.GetComponent<PlayerMovement>().speed = plyOriginSpeed;
        ply.GetComponent<PlayerMovement>().Hiding = false;
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
