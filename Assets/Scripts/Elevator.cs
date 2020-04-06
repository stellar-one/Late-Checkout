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
    float endTimer = 10f;
    bool doorOpened;
    int currentFloor = 0;
    int direction;
    public void CallElevator(int floor) 
    {
        if (floor > currentFloor)
        {
            direction = 1;
        }
        else if (floor < currentFloor)
        {
            direction = -1;

        }
        currentFloor = floor;
        
        
           
                


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

                if (direction == -1)
                {
                    if (elevator.transform.position.y <= target.transform.position.y)
                    {
                        Debug.Log("Arrivied");
                        callElevator = false;
                        OpenElevatorDoors();
                        doorOpened = true;

                    }
                    elevator.transform.position += -elevator.transform.up * Time.deltaTime;
                }


                else if (direction == 1)

                {
                    if (elevator.transform.position.y >= target.transform.position.y)
                    {
                        Debug.Log("Arrivied");
                        callElevator = false;
                        OpenElevatorDoors();
                        doorOpened = true;

                    }
                    elevator.transform.position += elevator.transform.up * Time.deltaTime;
                }
                else

                {
                    Debug.Log("Do Nothing");
                }
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
}
