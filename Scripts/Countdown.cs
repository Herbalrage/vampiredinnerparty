using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    //public TextMeshProUGUI countDownText;
    public GameObject countDown;
    public float gameTime = 60.0f;
    public GameObject skull;
    public GameObject smoke;
    private bool isCounting;

    private bool deathmatch = false;
    GameObject spawnSkull;

    // Start is called before the first frame update
    void Start()
    {
        isCounting = false;
        countDown.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCounting == true)
        {
            if (gameTime > 0 && !deathmatch)
            {
                gameTime -= Time.deltaTime;
                countDown.GetComponent<TextMeshProUGUI>().text = Mathf.RoundToInt(gameTime).ToString();
            }
            else if (gameTime <= 0 && !deathmatch)
            {
                deathmatch = true;

                spawnSkull = Instantiate(skull, countDown.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                spawnSkull.transform.parent = GameObject.FindGameObjectWithTag("UI").transform;

                foreach (GameObject npc in GameObject.FindGameObjectsWithTag("NPC"))
                {
                    Instantiate(smoke, npc.transform.position, Quaternion.Euler(-90, 0, 0));
                    Destroy(npc);
                }
                Destroy(countDown);
            }
            else
            {
                foreach (GameObject win in GameObject.FindGameObjectsWithTag("WinScreen"))
                {
                    if (win.activeSelf)
                    {
                        Destroy(spawnSkull);
                    }
                }
            }
        }
    }


    public void StartCounting()
    {
        isCounting = true;
        countDown.SetActive(true);
    }

    public void StopCountdown()
    {
        isCounting = false;
        countDown.SetActive(false);
    }
}
