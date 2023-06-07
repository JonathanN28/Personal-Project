using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 150;
    public float speed = 10;
    public float horizontalInput;
    public float verticalInput;
    public AudioClip moveSound;
    private AudioSource playerAudio;
    private Rigidbody playerRb;
    public Camera backCamera;

    public bool Hiding = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        if (horizontalInput == 1 || horizontalInput == -1 || verticalInput == 1 || verticalInput == -1)
        {
            if (IsInvoking("walking") == false)
            {
                InvokeRepeating("walking", 0, 0.5f);
            }
        }
        else
        {
            CancelInvoke("walking");
        }
        if (Input.GetKey(KeyCode.Period))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
        }

        if (Input.GetKey(KeyCode.Comma))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (!backCamera.CompareTag("Untagged"))
            {
               backCamera.enabled = true; 
            }
            
        }
        else
        {
            backCamera.enabled = false;
        }

        if (playerRb.velocity != new Vector3(0, 0, 0))
        {
            playerRb.velocity = new Vector3(0,0,0);
        }
    }

    private void walking()
    {
        playerAudio.PlayOneShot(moveSound);
    }
}
