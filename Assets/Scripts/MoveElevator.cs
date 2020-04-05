using UnityEngine;
using UnityEngine.AI;

public class MoveElevator : MonoBehaviour
{
    public Transform Floor { get { return currentFloor; } }
    Transform currentFloor;
    NavMeshAgent agent;
    public bool callElevator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (callElevator)
        {
            Debug.Log("Elevator coming to " + currentFloor);
            agent.SetDestination(currentFloor.position);
        }
        
    }

    public void ChangeTarget(Transform target)
    {
        currentFloor = target;
    }
}
