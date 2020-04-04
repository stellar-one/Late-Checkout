using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject movePlatform;

    public GameObject basement;
    public GameObject mainFloor;
    public GameObject firstFloor;
    public GameObject secondFloor;

    private void OnTriggerStay(Collider other) 
    {
        Debug.Log("Select the floor you wish to go to...");
        // movePlatform.transform.position += movePlatform.transform.up * Time.deltaTime;
    }
}
