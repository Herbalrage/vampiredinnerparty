using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private GameObject gameDirector;
    private GameObject roundEndScreen;
    private GameObject fadeFromBlack;
    private GameObject fadeToBlack;
    private AIMovement AIMove;

    public GameObject hunterLookScreen;
    public GameObject vampireLookScreen;
    public GameObject vampireAwayMessage;
    public GameObject hunterLocationMessage;
    public GameObject hunterAwayMessage;
    public GameObject vampireLocationMessage;

    public GameObject countdownScreen;
    public GameObject count3;
    public GameObject count2;
    public GameObject count1;

    private PlayerMovement playerObject1;
    private PlayerMovement playerObject2;

    public GameObject vampireWinScreen;
    public GameObject hunterWinScreen;
    public GameObject vampireWinText;
    public GameObject hunterWinText;

    public GameObject gameplayMusic;
    public GameObject winMusic;

    private Countdown countDown;

    private string winExplanation;

    // Start is called before the first frame update
    void Start()
    {
        countDown = GetComponentInChildren<Countdown>();
        playerObject1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMovement>();
        playerObject2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerMovement>();

        gameDirector = GameObject.FindGameObjectWithTag("GameDirector");
        roundEndScreen = GameObject.Find("RoundEndScreen");
        fadeFromBlack = GameObject.Find("FadeFromBlack");
        fadeToBlack = GameObject.Find("FadeToBlack");

        StartCoroutine(StartSequenceHiders());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartEndSequence(int playerIndex, string winQuote)
    {
        Debug.Log("start end sequence");

        if (playerIndex == 1)
        {
            winExplanation = winQuote;
            StartCoroutine(HunterWinGame());
        }
        else if (playerIndex == 2)
        {
            winExplanation = winQuote;
            StartCoroutine(VampireWinGame());
        }
    }

    IEnumerator StartSequenceHiders()
    {
        playerObject1.BlockMovement();
        playerObject2.BlockMovement();
        foreach(GameObject AI in GameObject.FindGameObjectsWithTag("NPC"))
        {
            AIMove = AI.GetComponent<AIMovement>();
            AIMove.BlockMovement();
        }
        //AIMove.BlockMovement();
        hunterLookScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        vampireAwayMessage.SetActive(true);
        yield return new WaitForSeconds(4);
        vampireAwayMessage.SetActive(false);
        hunterLocationMessage.SetActive(true);
        yield return new WaitForSeconds(4);
        hunterLookScreen.SetActive(false);
        playerObject1.DisplayRing();
        yield return new WaitForSeconds(4);
        vampireLookScreen.SetActive(true);
        hunterAwayMessage.SetActive(true);
        yield return new WaitForSeconds(4);
        hunterAwayMessage.SetActive(false);
        vampireLocationMessage.SetActive(true);
        yield return new WaitForSeconds(4);
        vampireLookScreen.SetActive(false);
        playerObject2.DisplayRing();
        yield return new WaitForSeconds(4);
        countdownScreen.SetActive(true);
        count3.SetActive(true);
        yield return new WaitForSeconds(1);
        count2.SetActive(true);
        count3.SetActive(false);
        yield return new WaitForSeconds(1);
        count1.SetActive(true);
        count2.SetActive(false);
        yield return new WaitForSeconds(1);
        countdownScreen.SetActive(false);
        playerObject1.AllowMovement();
        playerObject2.AllowMovement();
        foreach (GameObject AI in GameObject.FindGameObjectsWithTag("NPC"))
        {
            AIMove = AI.GetComponent<AIMovement>();
            AIMove.AllowMovement();
        }
        countDown.StartCounting();
    }

    IEnumerator VampireWinGame()
    {
        gameplayMusic.SetActive(false);
        winMusic.SetActive(true);
        yield return new WaitForSeconds(2);
        vampireWinScreen.SetActive(true);
        vampireWinText.GetComponent<TextMeshProUGUI>().text = winExplanation;
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(0);
    }

    IEnumerator HunterWinGame()
    {
        gameplayMusic.SetActive(false);
        winMusic.SetActive(true);
        yield return new WaitForSeconds(2);
        hunterWinScreen.SetActive(true);
        hunterWinText.GetComponent<TextMeshProUGUI>().text = winExplanation;
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(0);
    }
}
