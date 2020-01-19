using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer2 : RandomSpawn
{
    public GameObject player2Prefab;
    public RandomTexture randomTexture;

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    public void SpawnPlayerTwo()
    {
        bool validPosition = true;
        Collider[] hitColliders = Physics.OverlapSphere(RandomSpawn.randomCoordinate, 0.5f);

        foreach (Collider col in hitColliders)
        {
            if (col.tag == "NPC" || col.tag == "Obstacle" || col.tag == "Player1")
            {

                Debug.Log("OVERLAP");
                validPosition = false;
                Debug.Log(validPosition);
                RandomSpawn.i2--;

            }


        }

        if (validPosition == true)
        {
            randomTexture.GetRandomTexture();
            GameObject playerObject2 = Instantiate(player2Prefab, randomCoordinate, Quaternion.identity);

        }

    }
}

