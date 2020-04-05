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
                Debug.Log("Elevator coming to " + target);
                target = basement.transform;
                callElevator = true;
                break;
            case 1:
                Debug.Log("Elevator coming to " + target);
                target = mainFloor.transform;
                callElevator = true;
                break;
            case 2:
                Debug.Log("Elevator coming to " + target);
                target = firstFloor.transform;
                callElevator = true;
                break;
            case 3:
                Debug.Log("Elevator coming to " + target);
                target = roof.transform;
                callElevator = true;
                break;
            default:
                Debug.Log("Elevator Error");
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
