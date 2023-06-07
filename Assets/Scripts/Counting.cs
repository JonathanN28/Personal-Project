using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counting : MonoBehaviour
{
    public TextMeshProUGUI CountDown;
    public TextMeshProUGUI CountScore;
    public Text gameStatus;
    public int numberTime;

    public int AmountLeft;
    private int AmountLeftBefore;

    public GameObject ply;
    public GameObject teacher;
    public GameObject computers;

    // Start is called before the first frame update
    void Start()
    {
        numberTime = 20; // Default is 180
        AmountLeft = 30; // Default is 60
        AmountLeftBefore = AmountLeft;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CountDownTimer()
    {
        if (numberTime > 0)
        { 
            numberTime = numberTime - 1; 
            CountDown.text = "Time: " + numberTime.ToString(); 
        }
        else
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        int FinalScore = AmountLeft - AmountLeftBefore;
        FinalScore = Mathf.Abs(FinalScore);
        string EndScore = FinalScore.ToString();
        gameStatus.text = "Game Over! Score: " + EndScore;
        gameStatus.enabled = true;
        CancelInvoke("CountDownTimer");
        death();
    }

    public void death()
    {
        ply.GetComponent<PlayerMovement>().speed = 0;
        ply.GetComponent<PlayerMovement>().turnSpeed = 0;
        teacher.GetComponent<Collider>().enabled = false;
        computers.GetComponentInChildren<MaterialStorage>().CancelInvoke();
    }
    public void CarbonFootprint()
    {
        if (AmountLeft > 0)
        {
            AmountLeft = AmountLeft - 1;
            CountScore.text = "Computers, " + AmountLeft.ToString() + ", left to turn off.";
        }

        if (AmountLeft <= 0)
        { // might replace with GameOver function.
            //gameStatus.text = "You Win!"; 
            //gameStatus.enabled = true;
            //CancelInvoke("CountDownTimer");
            CountScore.text = "Find the nearest exit!";
        }
    }
}
