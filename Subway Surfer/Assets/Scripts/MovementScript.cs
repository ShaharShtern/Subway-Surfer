using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
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

    private Animator animator;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
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
   
}
