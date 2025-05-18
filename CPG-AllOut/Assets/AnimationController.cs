using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator{get;private set;}
    private string currentAnimation;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentAnimation = "Down";
    }

    public void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }


     public Animator Animator
    {
        get { return animator; }
    }
}