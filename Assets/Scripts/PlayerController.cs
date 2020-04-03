using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public LayerMask groundMask;
    public Transform groundCheck;
    Vector3 velocity;
    public float speed = 6f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            Sprint();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && isGrounded)
        {
            Walk();
        }

        if(Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            Crouch();
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl) && isGrounded)
        {
            Stand();
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
    }

    void Sprint()
    {
        speed = 8f;
    }

    void Walk()
    {
        speed = 6f;
    }

    void Crouch()
    {
        transform.localScale = new Vector3(1f, .5f, 1f);
        speed = 4f;
    }

    void Stand()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        speed = 6f;
    }
}