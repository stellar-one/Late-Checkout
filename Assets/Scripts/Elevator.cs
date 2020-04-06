using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject basement;
    public GameObject mainFloor;
    public GameObject firstFloor;
    public GameObject roof;

    public GameObject elevator;
    public GameObject elevatorDoor_L;
    public GameObject elevatorDoor_R;

    public int button;

    Transform target;
    bool callElevator;
    float startTimer;
    float endTimer = 7f;
    bool doorOpened;

    public void CallElevator(int floor) 
    {   
        switch (floor)
        {
            case 0:
                target = basement.transform;
                Debug.Log("Elevator coming to " + target);
                callElevator = true;
                break;
            case 1:
                target = mainFloor.transform;
                Debug.Log("Elevator coming to " + target);
                callElevator = true;
                break;
            case 2:
                target = firstFloor.transform;
                Debug.Log("Elevator coming to " + target);
                callElevator = true;
                break;
            case 3:
                target = roof.transform;
                Debug.Log("Elevator coming to " + target);
                callElevator = true;
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

    void CloseElevatorDoors()
    {
        elevatorDoor_L.GetComponent<Animator>().SetBool("Open", false);
        elevatorDoor_R.GetComponent<Animator>().SetBool("Open", false);
    }

    void Update()
    {
        if (callElevator && !doorOpened)
        {
            if (elevator.transform.position.y < target.transform.position.y) // up
            {
                Debug.Log("Going up...");
                elevator.transform.position += elevator.transform.up * Time.deltaTime;

                // if (elevator.transform.position.y == target.transform.position.y)
                // {
                //     Debug.Log("Arrived");
                //     arrived();
                // } -22 start --> -1
            }
            if (elevator.transform.position.y < target.transform.position.y) // down
            {
                Debug.Log("Going down...");
                elevator.transform.position += -elevator.transform.up * Time.deltaTime;

                // if (elevator.transform.position.y == target.transform.position.y)
                // {
                //     Debug.Log("Arrived");
                //     arrived();
                // }
            }
            // arrived(); 
            
        }
        
        else if (!callElevator && doorOpened)
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

    void arrived()
    {  
        callElevator = false;
        OpenElevatorDoors();
        doorOpened = true;
    }
}
