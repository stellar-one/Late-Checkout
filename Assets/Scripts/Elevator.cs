using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject basement;
    public GameObject mainFloor;
    public GameObject firstFloor;
    public GameObject roof;

    public GameObject elevator;
    GameObject elevatorDoor_L;
    GameObject elevatorDoor_R;

    public int button;

    Transform target;
    bool bringElevator;
    float startTimer;
    float endTimer = 7f;
    bool doorOpened;

    public void CallElevator(int floor) 
    {   
        switch (floor)
        {
            case 0:
                target = basement.transform;
                elevatorDoor_L = GameObject.FindWithTag("Left Basement Elevator");
                elevatorDoor_R = GameObject.FindWithTag("Right Basement Elevator");
                bringElevator = true;
                break;
            case 1:
                target = mainFloor.transform;
                elevatorDoor_L = GameObject.FindWithTag("Left Lobby Elevator");
                elevatorDoor_R = GameObject.FindWithTag("Right Lobby Elevator");
                bringElevator = true;
                break;
            case 2:
                target = firstFloor.transform;
                elevatorDoor_L = GameObject.FindWithTag("Left First Floor Elevator");
                elevatorDoor_R = GameObject.FindWithTag("Right First Floor Elevator");
                bringElevator = true;
                break;
            case 3:
                target = roof.transform;
                elevatorDoor_L = GameObject.FindWithTag("Left Roof Elevator");
                elevatorDoor_R = GameObject.FindWithTag("Right Roof Elevator");
                bringElevator = true;
                break;
            default:
                Debug.Log("Elevator Error");
                break;
        }   
    }

    void OpenElevatorDoors()
    {
        elevatorDoor_L.GetComponent<Animator>().SetBool("Open", true);
        elevatorDoor_R.GetComponent<Animator>().SetBool("Open", true);
    }

    public void CloseElevatorDoors()
    {
        elevatorDoor_L.GetComponent<Animator>().SetBool("Open", false);
        elevatorDoor_R.GetComponent<Animator>().SetBool("Open", false);
    }

    void Update()
    {
        if (bringElevator && !doorOpened)
        {
            if (Mathf.Round(elevator.transform.position.y) < Mathf.Round(target.transform.position.y)) // check to go up
            {
                elevator.transform.position += elevator.transform.up * Time.deltaTime;
            }
            else if (Mathf.Round(elevator.transform.position.y) > Mathf.Round(target.transform.position.y)) // check to go down
            {
                elevator.transform.position += -elevator.transform.up * Time.deltaTime;
            }
            else if(Mathf.Round(elevator.transform.position.y) == Mathf.Round(target.transform.position.y)) // check to see if at the target floor
            {
                Arrived();
            }
        }  
        else if (doorOpened)
        {
            ElevatorDoorsTimerStart();
        }    
    }

    void Arrived()
    {
        bringElevator = false;
        OpenElevatorDoors();
        doorOpened = true;
    }

    void ElevatorDoorsTimerStart()
    {
        startTimer += Time.deltaTime;
        if (startTimer >= endTimer)
        {
            startTimer = 0;
            CloseElevatorDoors();
            doorOpened = false;
        }
    }
}
