using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RangedEnemy : Character
{
    public GameObject arrowPrefab;
    public Transform arrowSpawn;

    private void Start()
    {
        attackRange = interactRange;
    }
    public override Vector2 EnemyInRange(float range)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastOffset, -Vector2.right, range, LayerMask.GetMask("Player"));
        if ((hit.collider != null) && (hit.collider.CompareTag("Player")))
        {
            return hit.point;
        }

        return Vector2.zero;
    }

    public override bool DoAttack()
    {
        Vector2 enemyPos = EnemyInRange(attackRange);
        if (enemyPos != Vector2.zero)
        {
            Attack(transform.position);
            return true;
        }

        return false;
    }

    public override void Attack(Vector2 enemyPos)
    {
        charaMovement.MoveTo(enemyPos);
    }

    public override void MoveDone()
    {
        switch (commandState)
        {
            case CharaState.Attack:
                {
                    SetCharaAnimationState(CharaState.Attack);
                    charaAnimation.SetSpeed(stats.attackSpeed);
                    break;
                }
        }
    }

    public override bool CanWalk(int direction = 1)
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

    public override void AttackAnimationDone()
    {
        GameObject arrowObject = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
        arrowObject.GetComponent<Arrow>().damage = stats.attack;
        arrowObject.SetActive(true);
        base.AttackAnimationDone();
    }
}
