using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private string attackInput;
    private string smokeInput;

    public GameObject smokePrefab;

    private PlayerMovement playerMovement;

    public bool IsAttacking;
    private bool smokeUsed;

    public GameObject colliderObject;



    // Start is called before the first frame update
    void Start()
    {
        smokeUsed = false;
        IsAttacking = false;
        playerMovement = GetComponent<PlayerMovement>();

        //Debug.Log(colliderObject.name);

        if (playerMovement.playerNum == 1)
        {
            //Debug.Log("Player 1 detected");
            //Debug.Log(playerMovement.playerNum);
            attackInput = ("P1Attack");
            smokeInput = ("P1Smoke");
        }
        else
        {
            Debug.Log("Player 2 detected");
            //Debug.Log(playerMovement.playerNum);
            attackInput = ("P2Attack");
            smokeInput = ("P2Smoke");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(attackInput + " from " + playerMovement.playerNum);
        if (Input.GetButtonDown(attackInput))
        {
            if (playerMovement.stopControl == false)
            {
                //Debug.Log("Attack from " + attackInput);
                IsAttacking = true;
                StartCoroutine(Attack());
            }
        }
        
        if (Input.GetButtonDown(smokeInput))
        {
            if (playerMovement.stopControl == false)
            {
                if (smokeUsed == false)
                {
                    smokeUsed = true;
                    Debug.Log("Attack from " + smokeInput);
                    StartCoroutine(SmokeBomb());
                }
            }
        }
    }

    IEnumerator Attack()
    {
        colliderObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        colliderObject.SetActive(false);
        IsAttacking = false;
    }

    IEnumerator SmokeBomb()
    {
        Instantiate(smokePrefab, transform.position, Quaternion.Euler(-90, 0, 0));
        yield return new WaitForSeconds(1);
    }
}
