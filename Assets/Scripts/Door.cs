using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
