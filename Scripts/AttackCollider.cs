using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private GameObject gameDirector;
    private UIManager uiManager;

    public float damageDealt;

    // Start is called before the first frame update
    void Start()
    {
        gameDirector = GameObject.FindGameObjectWithTag("GameDirector");
        playerMovement = GetComponentInParent<PlayerMovement>();
        uiManager = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player" + playerMovement.oppositePlayer))
        {
            
            other.GetComponent<HealthTracker>().TakeDamage(damageDealt);
            gameDirector.GetComponent<GameDirector>().AddScore(playerMovement.playerNum, "right");
            Debug.Log("player hit");


        }
        else if (other.tag == "NPC")
        {            
            other.GetComponent<HealthTracker>().TakeDamage(damageDealt);
            gameDirector.GetComponent<GameDirector>().AddScore(playerMovement.playerNum, "wrong");
            Debug.Log("NPC hit");

        }

    }
}
