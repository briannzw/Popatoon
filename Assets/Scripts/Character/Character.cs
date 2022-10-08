using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected CharaAnimation charaAnimation;
    protected CharaMovement charaMovement;
    public CommandSO[] commands;

    public Vector3 raycastOffset = new(0f, 0.5f, 0f);
    public float interactRange;

    public CharaState commandState;

    public bool trackEnemy;
    private Vector2 enemyPos = Vector2.zero;
    protected float attackRange;

    public int attackCount = 0;
    private int attackCounter = 0;

    [Header("Stats")]
    [SerializeField] protected Stats stats;

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

    public bool DoCommand(CommandSO commandSO)
    {
        switch (commandSO.state)
        {
            case CharaState.Walk:
                {
                    if (!CanWalk(commandSO.index)) return false;
                    break;
                }
            case CharaState.Attack:
                {
                    if (!DoAttack()) return false;
                    break;
                }
        }
        commandState = commandSO.state;
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
            enemyPos = EnemyInRange(attackRange);
            if (enemyPos == Vector2.zero)
            {
                commandState = CharaState.Idle;
                SetCharaAnimationState(CharaState.Idle);
                return;
            }

            if (Vector2.Distance(transform.position, enemyPos) > 1.1 * interactRange)
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastOffset, Vector2.right * direction, charaMovement.moveRange, LayerMask.GetMask("Enemy"));
        if ((hit.collider != null) && (hit.collider.CompareTag("Enemy")))
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

    public virtual void Hurt(int damage)
    {
        if (stats.health <= 0)
        {
            stats.health = 0;
            Debug.Log(gameObject.name + " Dead");
            Dead();
            return;
        }

        stats.health -= damage;
        Debug.Log(gameObject.name + " hurt by " + damage);
    }

    public virtual void Dead()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
        SetCharaAnimationState(CharaState.Dying);

        if (CompareTag("Player"))
        {
            StageManager.instance.PlayerDead();
        }

        if (CompareTag("Enemy"))
        {
            GetComponent<Enemy>().enabled = false;
            charaMovement.StopAllCoroutines();
            StageManager.instance.EnemyDead();
        }
    }
}
