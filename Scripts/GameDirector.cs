using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    private GameObject playerObject1;
    private GameObject playerObject2;

    public static int player1Score;
    public static int player2Score;

    private GameObject gameUI;
    private GameObject uiManager;
    private Countdown countDown;

    public GameObject stabPrefab;

    public bool roundEnded = false;

    private string winFeed;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("UI");
        countDown = uiManager.GetComponentInChildren<Countdown>();

        playerObject1 = GameObject.FindGameObjectWithTag("Player1");
        playerObject2 = GameObject.FindGameObjectWithTag("Player2");

        gameUI = GameObject.FindGameObjectWithTag("UI");


       // StartCoroutine(StartSequence());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerObject1);
        //Debug.Log(playerObject2);


        // CHECK
        if (roundEnded == false)
        {
            
        }

    }


    public void AddScore(int playerIndex, string rightOrWrong)
    {
        Debug.Log("addscore called");

        if (roundEnded == false)
        {
            if (playerIndex == 1)
            {
                if (rightOrWrong == "right")
                {
                    roundEnded = true;
                    player1Score = player1Score + 1;
                    winFeed = "The Hunter killed the Vampire!";
                }
                else
                {
                    roundEnded = true;
                    player2Score = player2Score + 1;
                    winFeed = "The Hunter killed an innocent!";
                }
            }
            else if (playerIndex == 2)
            {
                if (rightOrWrong == "right")
                {
                    roundEnded = true;
                    player2Score = player2Score + 1;
                    winFeed = "The Vampire killed the Hunter!";
                }
                else
                {
                    roundEnded = true;
                    player1Score = player1Score + 1;
                    winFeed = "The Vampire killed an innocent!";
                }
            }

            Debug.Log("P1 Score: " + player1Score);
            Debug.Log("P2 Score: " + player2Score);

            countDown.StopCountdown();

            Instantiate(stabPrefab);


            if (player1Score >= 1)
            {
                uiManager.GetComponent<UIManager>().StartEndSequence(1, winFeed);
            }
            else if (player2Score >= 1)
            {
                uiManager.GetComponent<UIManager>().StartEndSequence(2, winFeed);
            }

        }
    }


}

