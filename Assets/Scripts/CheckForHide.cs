using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForHide : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.gameObject.CompareTag("HideObject"))
            {
                if (gameObject.GetComponent<PlayerMovement>().Hiding == false)
                {
                    other.gameObject.GetComponent<EnableHide>().Hide();
                }
                else if (gameObject.GetComponent<PlayerMovement>().Hiding == true)
                {
                    other.gameObject.GetComponent<EnableHide>().UnHide();
                }
            }
        }
    }
}
