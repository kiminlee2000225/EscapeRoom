using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    public float moveSpeed = 5f;
    public float gravity = 9.81f;
    Vector3 moveDirection;
    public float jumpHeight = 3f;
    public float airControl = 10f;
    public AudioClip walkSFX;
    bool gameFinished;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.enabled = true;
        gameFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameFinished)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 input = transform.right * moveHorizontal + transform.forward * moveVertical;

            input *= moveSpeed;

            if (controller.isGrounded)
            {
                moveDirection = input;
                moveDirection.y = 0f;
            }
            else
            {
                input.y = moveDirection.y;
                moveDirection = Vector3.Lerp(moveDirection, input, airControl * Time.deltaTime);

            }

            moveDirection.y -= gravity * Time.deltaTime;

            controller.Move(moveDirection * Time.deltaTime);
        }
    }

    public void playerWon()
    {
        controller.enabled = false;
        gameFinished = true;
    }
}
