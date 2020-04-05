using UnityEngine;

public class MoveElevator : MonoBehaviour
{
    public Transform Floor { get { return currentFloor; } }
    Transform currentFloor;

    public void BringElevator(bool callElevator)
    {
        if (callElevator)
        {
            Debug.Log("Elevator coming to " + currentFloor);
            // bring elevator to currentFloor

        }
    }

    public void SetTarget(Transform target)
    {
        currentFloor = target;
    }
}
