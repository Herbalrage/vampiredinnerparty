using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator anim;

    PlayerMovement playerMovement;

    HealthTracker playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponentInParent<PlayerMovement>();
        playerHealth = GetComponentInParent<HealthTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.hasDied == true)
        {
            anim.SetBool("IsDead", true);
            anim.SetInteger("Movespeed", -1);
            return;
        }
        if (playerMovement.isRunning == true)
        {
            anim.SetInteger("Movespeed", 2);
            return;
        }
        if (playerMovement.isMoving == true)
        {
            anim.SetInteger("Movespeed", 1);
            return;
        }
        

        if (!anim.GetBool("IsDead"))
        {
            anim.SetInteger("Movespeed", 0);
        }
        //gameObject.transform.localRotation = gameObject.transform.parent.rotation;


    }

    public void SetDead()
    {

    }

    public void SetWalking()
    {

    }

    public void SetRunning()
    {

    }
}
