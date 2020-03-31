using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public LayerMask groundMask;
    public Transform groundCheck;
    Vector3 velocity;
    // ************************************************************
    // ************************** Speed ***************************
    // ************************************************************
    public float Speed { get { return currentSpeed; } }
    float currentSpeed;
    public float maxSpeed = 50f;
    // public TextMeshProUGUI speedTxt;
    // ************************************************************
    // *************************** Jump ***************************
    // ************************************************************
    public float Jump { get { return currentJump; } }
    float currentJump;
    public float maxJump = 25f;
    // public TextMeshProUGUI jumpTxt;
    // ************************************************************
    // ************************************************************
    // ************************************************************
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    bool isGrounded;

    void Start()
    {
        currentSpeed = 6f;
        // speedTxt.text = "Speed: " + currentSpeed.ToString();

        currentJump = 3f;
        // jumpTxt.text = "Jump: " + currentJump.ToString();
    }

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

        controller.Move(move * currentSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(currentJump * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    // public void ChangeSpeed(float amount)
    // {
    //     currentSpeed = Mathf.Clamp(currentSpeed + amount, 0, maxSpeed);
    //     speedTxt.text = "Speed: " + currentSpeed.ToString();
    // }

    // public void ChangeJump(float amount)
    // {
    //     currentJump = Mathf.Clamp(currentJump + amount, 0, maxJump);
    //     jumpTxt.text = "Jump: " + currentJump.ToString();
    // }
}