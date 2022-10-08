using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int moveInterval = 5;
    private float timer;

    private Character enemyMove;
    public CommandSO attackSO;

    private bool isAttacking = false;

    private void Awake()
    {
        enemyMove = GetComponent<Character>();
        StageManager.instance.EnemySpawn();
    }

    private void Update()
    {
        if (isAttacking)
        {
            if (enemyMove.commandState == CharaState.Idle) isAttacking = false;
            return;
        }

        timer += Time.deltaTime;
        if (timer > moveInterval)
        {
            timer = 0;
            if (enemyMove.DoCommand(attackSO))
            {
                isAttacking = true;
            }
        }
    }
}
