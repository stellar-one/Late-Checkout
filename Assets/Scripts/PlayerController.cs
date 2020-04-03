using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public LayerMask groundMask;
    public Transform groundCheck;
    Vector3 velocity;
    float speed = 12f;
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
            velocity.y = Mathf.Sqrt(speed * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}