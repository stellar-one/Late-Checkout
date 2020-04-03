using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;
    public PlayerController PC;




    void Start()
    {
        _animator = GetComponent<Animator>();
        PC = GetComponent<PlayerController>();


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !_animator.GetBool("Open") && PC.interact == true)
        {
            Debug.Log("Open Door");

            _animator.SetBool("Open", true);
        }
        else if (other.tag == "Player" && PC.interact == false)
        {
            Debug.Log("Close Door");
            _animator.SetBool("Open", false);
        }


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
