using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckForE : MonoBehaviour
{
    public GameObject ETurnOnText;
    public TextMeshProUGUI increaseTimerPopup;
    public TextMeshProUGUI exitPopup;
    public GameObject systemCounter;
    public AudioClip bootOffSound;
    private AudioSource computerAudio;

    // Start is called before the first frame update
    void Start()
    {
        computerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Computer"))
        {
            if (ETurnOnText.GetComponent<Text>().enabled == false)
            {
                ETurnOnText.GetComponent<Text>().enabled = true;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                other.gameObject.GetComponent<MaterialStorage>().ToggleMaterial();
                ETurnOnText.GetComponent<Text>().enabled = false;
                other.gameObject.GetComponent<Collider>().enabled = false;
                systemCounter.GetComponent<Counting>().CarbonFootprint();
                if (systemCounter.GetComponent<Counting>().AmountLeft > 0)
                {
                    systemCounter.GetComponent<Counting>().numberTime =
                        systemCounter.GetComponent<Counting>().numberTime + 4;
                    computerAudio.PlayOneShot(bootOffSound);
                    increaseTimerPopup.enabled = true;
                    if (IsInvoking("IncreaseTimerPopup") == false)
                    {
                        Invoke("IncreaseTimerPopup", 1);
                    }
                }
                else
                {
                    systemCounter.GetComponent<Counting>().computers.GetComponentInChildren<MaterialStorage>()
                        .CancelInvoke();
                }
            }
        }

        if (systemCounter.GetComponent<Counting>().AmountLeft == 0)
        {
            if (other.gameObject.CompareTag("Finish"))
            {
                exitPopup.enabled = true;
                if (Input.GetKey(KeyCode.E))
                {
                    systemCounter.GetComponent<Counting>().GameOver();
                    systemCounter.GetComponent<Counting>().gameStatus.text = "You Win!";
                }
            }
        }

    }
    private void IncreaseTimerPopup()
    {
        increaseTimerPopup.enabled = false;
    }
    private void OnTriggerExit(Collider other)
    {
        ETurnOnText.GetComponent<Text>().enabled = false;
        exitPopup.enabled = false;
    }
}
