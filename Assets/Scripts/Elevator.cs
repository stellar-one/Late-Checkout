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

    void Start()
    {
        GameObject elevator = GameObject.FindWithTag("Elevator");
    }

    public void CallElevator(int floor) 
    {
        switch (floor)
        {
            case 0:
                Debug.Log("Basement");
                break;
            case 1:
                // need to pass the gameobject transform to the MoveElevator script so the navmesh agent has a new target
                elevator.GetComponent<MoveElevator>().callElevator = true;
                elevator.GetComponent<MoveElevator>().ChangeTarget(mainFloor.transform);
                Debug.Log("Main Floor");
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
}
