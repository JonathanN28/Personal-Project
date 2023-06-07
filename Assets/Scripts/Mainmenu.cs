using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class Mainmenu : MonoBehaviour
{
    public GameObject EventSystem;
    public GameObject MainCamera;
    public GameObject Teacher;
    public GameObject SystemCounter;

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.GetComponent<TitleScreen>().enabled = true;
        MainCamera.GetComponent<FollowPlayer>().enabled = true;
        Teacher.GetComponent<NavMeshAgentMovement>().enabled = true;
        SystemCounter.GetComponent<Counting>().enabled = true;
        
        // Disables camera spinning around
        GetComponent<MainmenuCameraMove>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
