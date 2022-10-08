using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    protected CharaAnimation charaAnimation;
    protected CharaMovement charaMovement;

    public Vector3 raycastOffset = new(0f, 0.5f, 0f);
    public float interactRange;

    protected CharaState commandState;

    public bool trackEnemy;
    private Vector2 playerPos = Vector2.zero;
    protected float attackRange;

    public int attackCount = 0;
    private int attackCounter = 0;

    [Header("Stats")]
    [SerializeField] public Stats stats;

    private void Awake()
    {
        charaAnimation = GetComponent<CharaAnimation>();
        charaMovement = GetComponent<CharaMovement>();
    }

    public void SetCharaAnimationState(CharaState charaState)
    {
        if (charaAnimation == null) return;
        charaAnimation.state = charaState;
    }

    public bool DoMove(CharaState state)
    {
        switch (state)
        {
            case CharaState.Walk:
                {
                    if (!CanWalk()) return false;
                    break;
                }
            case CharaState.Attack:
                {
                    if (!DoAttack()) return false;
                    break;
                }
        }
        commandState = state;
        return true;
    }

    private void TrackEnemy()
    {
        if (!trackEnemy)
        {
            commandState = CharaState.Idle;
            SetCharaAnimationState(CharaState.Idle);
            return;
        }

        if (commandState == CharaState.Attack)
        {
            playerPos = EnemyInRange(attackRange);
            if (playerPos == Vector2.zero)
            {
                commandState = CharaState.Idle;
                SetCharaAnimationState(CharaState.Idle);
                return;
            }

            if (Vector2.Distance(transform.position, playerPos) > 1.1 * interactRange)
            {
                DoAttack();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + interactRange, transform.position.y, transform.position.z));
    }

    public virtual bool CanWalk(int direction = 1)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastOffset, Vector2.right * direction, charaMovement.moveRange, LayerMask.GetMask("Player"));
        if ((hit.collider != null) && (hit.collider.CompareTag("Player")))
        {
            //Can't move if there's enemy infront
            return false;
        }

        Walk(direction);
        return true;
    }

    public virtual Vector2 EnemyInRange(float range)
    {
        return Vector2.zero;
    }

    public virtual bool DoAttack()
    {
        return false;
    }

    public virtual void Walk(int index = 1)
    {
        charaMovement.Move(index);
    }

    public virtual void Attack(Vector2 enemyPos)
    {

    }

    public virtual void MoveDone()
    {

    }

    public virtual void AttackAnimationDone()
    {
        attackCounter++;
        if (attackCounter == attackCount)
        {
            attackCounter = 0;
            SetCharaAnimationState(CharaState.Idle);
            commandState = CharaState.Idle;
        }
        TrackEnemy();
    }
}
