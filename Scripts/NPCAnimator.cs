using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimator : MonoBehaviour
{
    private AIMovement aiMovement;

    private HealthTracker health;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        aiMovement = GetComponentInParent<AIMovement>();
        health = GetComponentInParent<HealthTracker>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.hasDied == true)
        {
            anim.SetBool("IsDead", true);
            anim.SetInteger("Movespeed", -1);
            aiMovement.BlockMovement();
            return;
        }
        if (aiMovement.isMoving == true)
        {
            anim.SetInteger("Movespeed", 1);
            return;
        }
        if (aiMovement.isDead == true)
        {
            anim.SetInteger("Movespeed", 2);
            return;
        }

        if (!anim.GetBool("IsDead"))
        {
            anim.SetInteger("Movespeed", 0);
        }

        //gameObject.transform.localRotation = gameObject.transform.parent.rotation;
    }
}
