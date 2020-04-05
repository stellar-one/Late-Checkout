using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject target;

    TriggerPatrol TP;
    NavMeshAgent myAgent;


    
    public Transform[] points;
    int destPoint = 0;

    [Header("Stats")]
    public float speed = 7f;
    public float agroRadius;
    public float attackDistance;
    public float attackCoolDown;
    public float Health = 10f;

    float startTimer;
    bool attacking = false;
    public bool ShowDebug;



    public void OnEnable()
    {
        TP = GetComponentInChildren<TriggerPatrol>();
        TP.agroRad = agroRadius;


    }



    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.speed = speed;
        myAgent.autoBraking = false;

        for (int i = 0; i < points.Length; i++)
        {
            points[i].GetComponent<MeshRenderer>().enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (attacking == true)
        {
            startTimer += Time.deltaTime;
            if ( startTimer >= attackCoolDown)
            {
                startTimer = 0f;
                Attack();
            }
        }

        if(target != null)
        {
            ChkDist();
        }



        if(!myAgent.pathPending && myAgent.remainingDistance <= 0.5f)
        {
            NextPoint();
        }
    }


    void NextPoint()
    {
        if(points.Length == 0)
        {
            return;
        }
        myAgent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;



    }



    void ChkDist()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);


        if(dist <= attackDistance)
        {
            attacking = true;
            myAgent.isStopped = true;
        }
        else
        {

            myAgent.isStopped = false;
            myAgent.destination = target.transform.position;
            attacking = false;
        }
    }

    void Attack()
    {
        print("attacking");

    }

    void TakeDamage()
    {

    }










   void OnDrawGizmos()
    {

        if (ShowDebug)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackDistance);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, agroRadius);

            Gizmos.color = Color.blue;
            for(int i = 0; i < points.Length; i++)
            {
                Gizmos.DrawWireSphere(points[i].position, 0.5f);
            }


        }



    }









}
