using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MG_AnimationHandler : MonoBehaviour
{
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");
    private static readonly int IsDie = Animator.StringToHash("IsDie");

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void DamageOn()
    {
        animator.SetBool(IsDamage, true);
    }

    public void DamageOff()
    {
        animator.SetBool(IsDamage, false);
    }

    public void Die()
    {
        animator.SetBool(IsDie, true);
    }
}
