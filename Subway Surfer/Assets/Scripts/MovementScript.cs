using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private CharacterController characterController;
    public Vector3 direction;
    public float jumpForce;
    public float gravityForce;
    private int currentLane;
    public float laneDistance;
    public float laneSwitchSpeed;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = jumpForce;
            }
        }
        else
        {
            direction.y += gravityForce * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentLane = Mathf.Clamp(currentLane - 1, -1, 1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentLane = Mathf.Clamp(currentLane + 1, -1, 1);
        }
        direction.x = (-transform.position.x + currentLane * laneDistance) * laneSwitchSpeed;
    }
    private void FixedUpdate()
    {
        characterController.Move(direction * Time.fixedDeltaTime);
    }
}
