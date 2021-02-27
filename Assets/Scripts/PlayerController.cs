﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController cc;
    public LayerMask groundMask;
    public Transform groundCheck;
    Vector3 velocity;
    float speed = 6f;
    float jumpHeight = 2f;
    float gravity = -9.81f;
    float groundDistance = 0.4f;
    bool isGrounded;
    GameObject target;

    void Start()
    {
        cc = GetComponent<CharacterController>();
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

        cc.Move(move * speed * Time.deltaTime);

        target = Camera.main.GetComponent<MouseLook>().RaycastedObj;

        if (Input.GetKeyDown("e")) // interact key
        {
            if (target.CompareTag("Elevator Buttons"))
            {
                Debug.Log("Calling Elevator...");
                target.GetComponent<Elevator>().CallElevator(target.GetComponent<Elevator>().button);                
            }

            if (target.CompareTag("Openable")) // && !target.GetComponent<Animator>().GetBool("Open"))
            {
                Debug.Log("Opening...");
                target.tag = "Closable";
                // target.GetComponent<Animator>().SetBool("Open", true);
            }

            else if (target.CompareTag("Closable")) // && target.GetComponent<Animator>().GetBool("Open"))
            {
                Debug.Log("Closing...");
                target.tag = "Openable";
                // target.GetComponent<Animator>().SetBool("Open", false);
            }

            if (target.CompareTag("Item"))
            {
                Debug.Log("Picking up item...");
                target.SetActive(false);
            }

            if (target.CompareTag("Inspect"))
            {
                Debug.Log("Inspecting item");
                //cc.enabled = false;
                
            }
            
        }


        // if(Input.GetButtonDown("Jump") && isGrounded)
        // {
        //     Jump();
        // }

        // if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        // {
        //     Sprint();
        // }
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

        cc.Move(velocity * Time.deltaTime);
    }

    // void Jump()
    // {
    //     velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
    // }

    // void Sprint()
    // {
    //     speed = 8f;
    // }

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