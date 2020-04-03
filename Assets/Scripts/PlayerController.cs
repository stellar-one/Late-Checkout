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
            velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
        }

        if(Input.GetKey(KeyCode.LeftControl) && isGrounded)
        {
            controller.height = 1.0f;
            // transform.localScale = new Vector3(0f, .5f, 0f);
        }
        else
        {
            controller.height = 2.0f;
            // transform.localScale = new Vector3(0f, 1f, 0f);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}