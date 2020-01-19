using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : RandomSpawn
{
    public GameObject player1Prefab;
    public static int numberOfPlayer = 1;
    public RandomTexture randomTexture;


    void Start()
    {

    }

    void Update()
    {
        
    }




    public void SpawnPlayerOne()
    {
        bool validPosition = true;
        Collider[] hitColliders = Physics.OverlapSphere(RandomSpawn.randomCoordinate, 0.5f);

        foreach (Collider col in hitColliders)
        {
            if (col.tag == "NPC" || col.tag == "Obstacle" || col.tag == "Player2")
            {

                Debug.Log("OVERLAP");
                validPosition = false;
                Debug.Log(validPosition);
                RandomSpawn.i1--;
                randomTexture.GetRandomTexture();
            }


        }

        if (validPosition == true)
        {
            randomTexture.GetRandomTexture();
            GameObject playerObject1 = Instantiate(player1Prefab, randomCoordinate, Quaternion.identity);


        }

    }
}
 
