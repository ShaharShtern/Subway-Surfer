using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private CharacterController characterController;
    public Vector3 direction;
    public float jumpForce;
    public float gravityForce;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        direction.y += gravityForce * Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.Space) && characterController.isGrounded)
        {
            direction.y = jumpForce;
        }
    }
    private void FixedUpdate()
    {
        characterController.Move(direction * Time.fixedDeltaTime);
    }
}
