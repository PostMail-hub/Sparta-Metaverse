using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");

    private static readonly int IsOpening = Animator.StringToHash("IsOpen");

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Move(Vector2 obj)
    {
        animator.SetBool(IsMoving, obj.magnitude > .5f);
    }

    public void IsBoxOpen()
    {
        animator.SetBool(IsOpening, true);
    }
    public void IsBoxClose()
    {
        animator.SetBool(IsOpening, false);
    }
}