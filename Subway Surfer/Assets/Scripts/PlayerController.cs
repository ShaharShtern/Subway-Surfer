using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isRunning=false;

    private CharacterController characterController;
    public Vector3 direction;
    public float jumpForce;
    public float gravityForce;
    private int currentLane;
    public float laneDistance;
    public float laneSwitchSpeed;
    public SwipeDetector swipeDetector;
    [SerializeField] private GameManager gameManager;
    private Animator animator;
    private PlayerSound playerSound;
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        playerSound = GetComponent<PlayerSound>();
    }

    void Update()
    {
        if (!isRunning) { return; }

        if (characterController.isGrounded)
        {
            if (Input.GetKeyDown("w") || swipeDetector.swipeUp)
            {
                direction.y = jumpForce;
                animator.SetTrigger("Jump");

                playerSound.PlayJumpSound();
            }
        }
        else
        {
            direction.y += gravityForce * Time.deltaTime;
        }
        if (Input.GetKeyDown("a")|| swipeDetector.swipeLeft)
        {
            currentLane = Mathf.Clamp(currentLane - 1, -1, 1);
        }
        if (Input.GetKeyDown("d") || swipeDetector.swipeRight)
        {
            currentLane = Mathf.Clamp(currentLane + 1, -1, 1);
        }
        direction.x = (-transform.position.x + currentLane * laneDistance) * laneSwitchSpeed;
    }
    private void FixedUpdate()
    {
        if (!isRunning) { return; }
        characterController.Move(direction * Time.fixedDeltaTime);
    }
    public void StartRunning()
    {
        isRunning = true;
        animator.SetTrigger("StartRunning");
    }
   
    public void StopRunning ()
    {
        isRunning = false;

    }
    
}
