using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject elevator;
    public GameObject basement;
    public GameObject mainFloor;
    public GameObject firstFloor;
    public GameObject roof;
    public GameObject elevatorDoor_L;
    public GameObject elevatorDoor_R;

    public void CallElevator(bool t) 
    {
        if (t && !elevatorDoor_L.GetComponent<Animator>().GetBool("Open") && !elevatorDoor_R.GetComponent<Animator>().GetBool("Open"))
        {
            OpenElevatorDoors();
        }

        else if (t && elevatorDoor_L.GetComponent<Animator>().GetBool("Open") && elevatorDoor_R.GetComponent<Animator>().GetBool("Open"))
        {
            CloseElevatorDoors();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Select the floor you wish to go to...");
        // elevator.transform.position += elevator.transform.up * Time.deltaTime;
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
