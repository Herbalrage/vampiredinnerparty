using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;

    private GameDirector gameDirector;
    private PlayerAttack playerAttack;

    public float playerSpeed;
    public float runningSpeed;

    private Vector3 moveDirection;
    private Vector3 lookDirection;
    private Vector3 runAxis;

    public bool isMoving;
    public bool isRunning;

    public int playerNum;
    public int oppositePlayer;

    public GameObject ringObject;

    private string horizontalInput;
    private string verticalInput;
    private string runInput;

    public bool roundLost;
    public bool roundWon;

    [SerializeField]
    private float lookSpeed;

    public bool IsMoveable;

    public bool stopControl = false;

    void Start()
    {
        isRunning = false;
        isMoving = false;
        gameDirector = GameObject.FindGameObjectWithTag("GameDirector").GetComponent<GameDirector>();
        roundWon = false;
        roundLost = false;
        ringObject = transform.Find("ring").gameObject;
        characterController = GetComponent<CharacterController>();
        playerAttack = GetComponentInChildren<PlayerAttack>();

        if (playerNum == 1)
        {
            Debug.Log("Player 1 detected");
            oppositePlayer = 2;
            horizontalInput = ("P1LeftStickHorizontal");
            verticalInput = ("P1LeftStickVertical");
            runInput = ("P1Run");
        }
        else
        {
            Debug.Log("Player 2 detected");
            oppositePlayer = 1;
            horizontalInput = ("P2LeftStickHorizontal");
            verticalInput = ("P2LeftStickVertical");
            runInput = ("P2Run");
        }

    }

    void FixedUpdate()
    {
        moveDirection = new Vector3(Input.GetAxisRaw(horizontalInput), 0, Input.GetAxisRaw(verticalInput));

        if (moveDirection.magnitude > 0.6f)
        {
            if (stopControl == false)
            {
                //Debug.Log(Input.GetAxis(horizontalInput));
                //Debug.Log(Input.GetAxis(verticalInput));

                moveDirection.Normalize();
                moveDirection *= playerSpeed;

                characterController.Move(moveDirection);
            }
        }

    }

    void Update()
    {
        Vector3 lookDirection = new Vector3(Input.GetAxis(horizontalInput), 0, Input.GetAxis(verticalInput));

        if (stopControl == false)
        {
            if (lookDirection.magnitude > 0.6f)
            {
                var angle = Mathf.Atan2(Input.GetAxis(horizontalInput), Input.GetAxis(verticalInput)) * Mathf.Rad2Deg;
                //transform.rotation = Quaternion.Euler(0, angle, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, angle, 0), lookSpeed * Time.deltaTime);
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, angle, 0), lookSpeed * Time.deltaTime);
                isMoving = true;

            }
            else
            {
                isMoving = false;
            }

            if (Input.GetAxis(runInput) > 0)
            {
                Debug.Log("running");
                isRunning = true;
                playerSpeed = runningSpeed;
            }
            else
            {
                isRunning = false;
                playerSpeed = 0.05f;
            }

        }

        // STOPS MOVEMENT AFTER ROUND HAS ENDED
        if (gameDirector.roundEnded == true)
        {
            BlockMovement();
        }
  
    }

    public void DisplayRing()
    {
        //Debug.Log("ring displayed");
        StartCoroutine(RingEffect());
    }

    IEnumerator RingEffect()
    {
        ringObject.SetActive(true);
        yield return new WaitForSeconds(4);
        ringObject.SetActive(false);
    }

    public void BlockMovement()
    {
        Debug.Log("blocked");
        stopControl = true;
    }

    public void AllowMovement()
    {
        Debug.Log("allowed");
        stopControl = false;
    }



}