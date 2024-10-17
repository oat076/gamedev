using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSControllerV2 : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 9f;
    public float jumpPower = 8f;
    public float gravity = 20f;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
                                                            // Variables
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (playerCamera == null)
        {
            Debug.LogError("Player camera is not assigned.");
        }
    }

    void Update()
    {
        if (characterController == null) return;

        HandleMovement();
        HandleRotation();
    }

    // Moving around with WASD and Space and LeftShift
    void HandleMovement()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = isRunning ? runSpeed : walkSpeed;
        float curSpeedY = isRunning ? runSpeed : walkSpeed;
        
        float moveDirectionY = moveDirection.y;
        moveDirection = (forward * Input.GetAxis("Vertical") * curSpeedX) + (right * Input.GetAxis("Horizontal") * curSpeedY);

        if (characterController.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpPower;
            }
            else
            {
                moveDirection.y = 0;
            }
        }
        else
        {
            moveDirection.y = moveDirectionY - (gravity * Time.deltaTime);
        }

        characterController.Move(moveDirection * Time.deltaTime);
    }

    // Looking around with mouse
    void HandleRotation()
    {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}
