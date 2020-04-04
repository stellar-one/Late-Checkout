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

    private void OnTriggerStay(Collider other) 
    {
        Debug.Log("Select the floor you wish to go to...");
        // elevator.transform.position += elevator.transform.up * Time.deltaTime;
    }
}
