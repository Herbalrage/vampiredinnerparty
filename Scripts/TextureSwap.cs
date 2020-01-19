using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSwap : MonoBehaviour
{
    private Material mat;
    private GameObject closestNPC = null;
    public string swapInput;
    public GameObject model;

    PlayerMovement playerMovement;
    

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        if (playerMovement.playerNum == 1)
        {
            swapInput = ("P1Disguise");
        }
        else
        {
            swapInput = ("P2Disguise");
        }
    }

    void Update()
    {
        Debug.Log(swapInput);
        if (Input.GetButtonDown(swapInput))
        {
            if (playerMovement.stopControl == false)
            {
                FindClosestNPC();

                foreach (Transform child in model.transform)
                {
                    if (child.GetComponent<Renderer>() != null)
                    {
                        child.GetComponent<Renderer>().material = closestNPC.GetComponent<Renderer>().material;
                    }
                }
            }
        }
    }

    public void FindClosestNPC()
    {
        float distanceToClosestNPC = Mathf.Infinity;

        GameObject[] allNPCS = GameObject.FindGameObjectsWithTag("NPC");

        foreach (GameObject currentNPC in allNPCS)
        {
            float distanceToNPC = (currentNPC.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToNPC < distanceToClosestNPC)
            {
                distanceToClosestNPC = distanceToNPC;
                closestNPC = currentNPC;
            }
        }
    }
}
