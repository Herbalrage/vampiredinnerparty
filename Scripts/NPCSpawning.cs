using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawning : RandomSpawn
{
    public GameObject npcPrefab;
    public static int numberOfNPCS = 50;
    public RandomTexture randomTexture;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SpawnNPC()
    {
       

        bool validPosition = true;
        Collider[] hitColliders = Physics.OverlapSphere(RandomSpawn.randomCoordinate, 0.2f);

        foreach (Collider col in hitColliders)
        {
            if (col.tag == "NPC" || col.tag == "Obstacle" || col.tag == "Player1" || col.tag == "Player2")
            {

                validPosition = false;
                Debug.Log(validPosition);
                numberOfNPCS--;
                RandomSpawn.i3--;
                randomTexture.GetRandomTexture();

            }
           
       
        }
        
        if (validPosition == true)
        {

            
            
            GameObject newNPC = Instantiate(npcPrefab, randomCoordinate, Quaternion.identity);
            GameObject[] allNPCS = GameObject.FindGameObjectsWithTag("NPC");
            foreach (GameObject currentNPC in allNPCS)
            {
                randomTexture.GetRandomTexture();
            }




        }
        
    }
}
