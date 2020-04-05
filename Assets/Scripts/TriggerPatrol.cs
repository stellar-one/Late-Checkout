using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPatrol : MonoBehaviour
{

    EnemyPatrol EP;

    SphereCollider myCollider;
    public float agroRad;


     void Start()
    {
        EP = GetComponentInParent<EnemyPatrol>();

        myCollider = GetComponent<SphereCollider>();
        myCollider.radius = agroRad;
        myCollider.isTrigger = true;

    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
            print("Danger");


        EP.target = coll.gameObject;

    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
            print("Safe");
        EP.target = null;
    }
}
