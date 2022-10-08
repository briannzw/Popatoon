using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharaAnimation : MonoBehaviour
{
    public CharaState state;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateAnimator();
    }

    #region Methods
    void UpdateAnimator()
    {
        switch (state)
        {
            case CharaState.Idle: { animator.Play("Idle"); break; }
            case CharaState.Walk: { animator.Play("Walking"); break; }
            case CharaState.Attack: { animator.Play("Attacking"); break; }
            case CharaState.Taunt: { animator.Play("Taunt"); break; }
            case CharaState.Dying: { animator.Play("Dying"); break; }
        }
    }

    public void SetSpeed(float speed)
    {
        switch (state)
        {
            case CharaState.Attack: { animator.SetFloat("attackSpeed", speed); break; }
        }
    }
    #endregion
}
