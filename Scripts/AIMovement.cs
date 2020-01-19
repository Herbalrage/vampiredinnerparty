using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class AIMovement : MonoBehaviour
{
    public float speed = 2;
    public float directionChangeInterval = 2.0f;
    public float maxHeadingChange = 180;
    public float minWaitTime = 2.0f;
    public float maxWaitTime = 7.0f;
    public float minWalkTime = 3.0f;
    public float maxWalkTime = 10.0f;
    public float lookAhead = 2.0f;
    public float secToWaitAfterWallHit = 2.0f;

    private CharacterController controller;
    private float heading;
    private float walkTime;
    private Quaternion targetRotation;
    private float timePassed = 0.0f;
    private bool nearWall = false;
    private bool move = true;

    public bool isMoving;
    public bool isDead;


    void Awake()
    {
        isMoving = false;
        isDead = false;

        controller = GetComponent<CharacterController>();

        heading = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(0, heading, 0);

        StartCoroutine(NewHeading());
    }

    void Update()
    {
        RaycastHit hit;

        if (timePassed < walkTime)
        {
            if (move)
            {
                if (!nearWall)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * directionChangeInterval);
                }
                isMoving = true;
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                controller.SimpleMove(forward * speed);
                timePassed += Time.deltaTime;
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(transform.forward), out hit, lookAhead))
            {
                if (hit.collider.tag == "Obstacle")
                {
                    
                    nearWall = true;
                    transform.rotation = Quaternion.AngleAxis(Random.Range(90, 180), transform.up) * transform.rotation;
                    targetRotation = transform.rotation;
                    StartCoroutine(TimeToMoveAway());
                }
            }
        }
        else
        {
            StartCoroutine(Wait());
        }

    }

    public void BlockMovement()
    {
        move = false;
    }

    public void AllowMovement()
    {
        move = true;
    }


    IEnumerator NewHeading()
    {
        while (true)
        {
            float min = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
            float max = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
            heading = Random.Range(min, max);
            targetRotation = Quaternion.Euler(0, heading, 0);
            walkTime = Random.Range(minWalkTime, maxWalkTime);
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    IEnumerator TimeToMoveAway()
    {
        yield return new WaitForSeconds(secToWaitAfterWallHit);
        nearWall = false;
    }

    IEnumerator Wait()
    {
        isMoving = false;
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        timePassed = 0f;
    }
}