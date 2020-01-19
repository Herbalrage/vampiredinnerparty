using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTracker : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    public GameObject bloodPrefab;
    private AIMovement aiMove;
    private PlayerMovement playerMove;
   
    public bool hasDied = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Instantiate(bloodPrefab, transform.position, Quaternion.Euler(90, 0, 0));
            /*aiMove.isMoving = false;
            playerMove.isMoving = false;
            playerMove.isRunning = false;*/
            hasDied = true;
            //Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
    }

    public void RestoreHealth(float amount)
    {
        currentHealth = currentHealth + amount;
    }
}
