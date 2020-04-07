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
    GameObject target;
    GameObject elevator;
    

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

        target = Camera.main.GetComponent<MouseLook>().RaycastedObj;

        if (Input.GetKeyDown("e")) // interact key
        {
            if (target.CompareTag("Elevator Buttons"))
            {
                elevator = target;
                target.GetComponent<Elevator>().CallElevator(target.GetComponent<Elevator>().button);
            }
            
            if (target.name == "Basement")
            {
                elevator.GetComponent<Elevator>().CloseElevatorDoors();
                elevator.GetComponent<Elevator>().CallElevator(0);
            }
            if (target.name == "Main Floor")
            {
                elevator.GetComponent<Elevator>().CloseElevatorDoors();
                elevator.GetComponent<Elevator>().CallElevator(1);
            }
            if (target.name == "First Floor")
            {
                elevator.GetComponent<Elevator>().CloseElevatorDoors();
                elevator.GetComponent<Elevator>().CallElevator(2);
            }
            if (target.name == "Roof")
            {
                elevator.GetComponent<Elevator>().CloseElevatorDoors();
                elevator.GetComponent<Elevator>().CallElevator(3);
            }

            if (target.CompareTag("Openable") && !target.GetComponent<Animator>().GetBool("Open"))
            {
                Open();
            }
            else if (target.CompareTag("Openable") && target.GetComponent<Animator>().GetBool("Open"))
            {
                Close();
            }

            if (target.CompareTag("Item"))
            {
                PickupItem(target);
            }
            
        }


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

    void Open()
    {
        target.GetComponent<Animator>().SetBool("Open", true);
    }

    void Close()
    {
        target.GetComponent<Animator>().SetBool("Open", false);
    }

    void PickupItem(GameObject item)
    {
        Debug.Log("Adding " + item.name + "...");
        // add item based on priority list:
        // 1: Hand, if empty
        // 2: Hotbox, if empty
        // 3: Inventory, if empty
        // 4: alert "Inventory full"
        item.SetActive(false);
    }
}