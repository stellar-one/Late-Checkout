using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private CharacterController _characterController;
    Vector3 velocity;
    public float speed = 6.0f;
    public float jumpHeight = 2.0f;
    public float gravity = -9.81f;
    GameObject target;
    GameObject elevator;
    public Inventory inventory;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(_characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _characterController.Move(move * speed * Time.deltaTime);

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
                IInventoryItem item = target.GetComponent<IInventoryItem>();
                if(item != null)
                {
                    inventory.AddItem(item);
                }
            }
            
        }

        if(Input.GetButtonDown("Jump") && _characterController.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && _characterController.isGrounded)
        {
            speed = 8f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && _characterController.isGrounded)
        {
            speed = 6f;
        }

        if(Input.GetKeyDown(KeyCode.LeftControl) && _characterController.isGrounded)
        {
            transform.localScale = new Vector3(1f, .5f, 1f);
            speed = 4f;
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl) && _characterController.isGrounded)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            speed = 6f;
        }

        velocity.y += gravity * Time.deltaTime;

        _characterController.Move(velocity * Time.deltaTime);
    }

    void Open()
    {
        target.GetComponent<Animator>().SetBool("Open", true);
    }

    void Close()
    {
        target.GetComponent<Animator>().SetBool("Open", false);
    }
}