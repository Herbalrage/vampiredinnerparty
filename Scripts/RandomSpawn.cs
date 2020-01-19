using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{

    public static Vector3 randomCoordinate;
    public static int i1 = 0;
    public static int i2 = 0;
    public static int i3 = 0;
    public NPCSpawning npcSpawning;
    public SpawnPlayer spawnPlayer;
    public SpawnPlayer2 spawnPlayer2;



    void Start()
    {
      
       
    }


    void Awake()
    {
        
        SpawnPlayer1();
        SpawnPlayer2();
        SpawnNPCS();
        


    }

    public void SpawnPlayer1()
    {
        for (i1 = 0; i1 < SpawnPlayer.numberOfPlayer; i1++)
        {
           

            Vector3 origin = transform.position;
            Vector3 range = transform.localScale / 2.0f;
            Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x),
                                          Random.Range(-range.y, range.y),
                                          Random.Range(-range.z, range.z));
            randomCoordinate = origin + randomRange;
            spawnPlayer.SpawnPlayerOne();

        }
    }


    public void SpawnPlayer2()
    {
        for (i2 = 0; i2 < SpawnPlayer.numberOfPlayer; i2++)
        {


            Vector3 origin = transform.position;
            Vector3 range = transform.localScale / 2.0f;
            Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x),
                                          Random.Range(-range.y, range.y),
                                          Random.Range(-range.z, range.z));
            randomCoordinate = origin + randomRange;
            spawnPlayer2.SpawnPlayerTwo();

        }
    }

    public void SpawnNPCS()
    {

        

            for (i3 = 0; i3 < NPCSpawning.numberOfNPCS; i3++)
        {


            Vector3 origin = transform.position;
            Vector3 range = transform.localScale / 2.0f;
            Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x),
                                          Random.Range(-range.y, range.y),
                                          Random.Range(-range.z, range.z));
            randomCoordinate = origin + randomRange;
            npcSpawning.SpawnNPC();
            



        }
    }



    public Color GizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);

    void OnDrawGizmos()
    {
        Gizmos.color = GizmosColor;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}

