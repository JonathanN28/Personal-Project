using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class TitleScreen : MonoBehaviour
{
    public Text title;

    public Image titleBackground;
    public GameObject ply;
    public GameObject teacher;
    public GameObject systemCounter;

    public TextMeshProUGUI objective;
    public TextMeshProUGUI CountDown;
    public TextMeshProUGUI CarbonFootPrint;
    public Text Title;
    public Image TitleBackground;
    public Button playButton;
    public TextMeshProUGUI playButtonText;

    // Start is called before the first frame update
    void Start()
    {
        CountDown.enabled = true;
        CarbonFootPrint.enabled = true;
        Title.enabled = true;
        TitleBackground.enabled = true;
        playButton.enabled = false;
        playButton.image.enabled = false;
        playButtonText.enabled = false;
        objective.enabled = false;
        ply.GetComponent<PlayerMovement>().backCamera.tag = "Used";
        Invoke("titleChanging", 4);
        InvokeRepeating("transition", 0, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        ;
    }

    private void titleChanging()
    {
        CancelInvoke("transition");
        title.enabled = false;
        titleBackground.enabled = false;
        systemCounter.GetComponent<Counting>().InvokeRepeating("CountDownTimer", 0, 1);
        ply.GetComponent<PlayerMovement>().speed = 6;
        ply.GetComponent<PlayerMovement>().turnSpeed = 120;
        ply.GetComponent<PlayerMovement>().Hiding = false;
    }

    private void transition()
    {
        titleBackground.color = new Color(0, 0, 0, titleBackground.color.a - 0.01f);
        title.color = new Color(255, 255, 255, title.color.a - 0.01f);
    }
}
