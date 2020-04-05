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

    public void CallElevator(int floor) 
    {
        switch (floor)
        {
            case 0:
                Debug.Log("Basement");
                break;
            case 1:
                Debug.Log("You are on the Main Floor");
                target = mainFloor.transform;
                Debug.Log("Elevator coming to " + target);
                callElevator = true;
                break;
            case 2:
                Debug.Log("1st Floor");
                break;
            case 3:
                Debug.Log("Roof");
                break;
            default:
                Debug.Log("Invalid Floor dumbass");
                break;
        }


        if (!elevatorDoor_L.GetComponent<Animator>().GetBool("Open") && !elevatorDoor_R.GetComponent<Animator>().GetBool("Open"))
        {
            OpenElevatorDoors();
        }

        else if (elevatorDoor_L.GetComponent<Animator>().GetBool("Open") && elevatorDoor_R.GetComponent<Animator>().GetBool("Open"))
        {
            CloseElevatorDoors();
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
        if (callElevator)
        {
            if (elevator.transform.position.y >= target.transform.position.y)
            {
                Debug.Log("STOP?");
                callElevator = false;
                return;
            }
            elevator.transform.position += elevator.transform.up * Time.deltaTime;
        }
    }
}
