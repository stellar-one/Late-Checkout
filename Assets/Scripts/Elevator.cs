using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject movePlatform;

    private void OnTriggerStay(Collider other) 
    {
        movePlatform.transform.position += movePlatform.transform.up * Time.deltaTime;
    }
}
