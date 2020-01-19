using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTexture : MonoBehaviour
{
    public Material[] materials;
    private Renderer Object;
    public GameObject model;
    private int index = 0;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetRandomTexture()
    {
        index = Random.Range(0, materials.Length);
        foreach (Transform child in model.transform)
        {
            if (child.GetComponent<Renderer>() != null)
            {
                Object = child.GetComponent<Renderer>();
                Object.material = materials[index];
            }
        }

    }
}

