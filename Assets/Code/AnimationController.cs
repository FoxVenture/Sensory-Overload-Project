using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;


    void Start()
    {

    }

    public void Trigger(string name)
    {
        animator.SetTrigger(name);
    }
}
