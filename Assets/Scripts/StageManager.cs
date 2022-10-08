using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class StageManager : MonoBehaviour
{
    private int enemyCount = 0;
    private int playerCount = 0;

    public static StageManager instance;


    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("There's more than one StageManager in this scene!");
        }
        else
        {
            enemyCount = 0;
            playerCount = 0;
            instance = this;
        }
    }

    public void PlayerSpawn(int count)
    {
        playerCount = count;
    }

    public void PlayerDead()
    {
        playerCount--;
        if(playerCount <= 0)
        {
            StageLose();
        }
    }

    public void EnemySpawn()
    {
        enemyCount++;
    }

    public void EnemyDead()
    {
        enemyCount--;
        if(enemyCount <= 0)
        {
            StageWon();
            CharaManager.instance.Win();
        }
    }
    
    public void StageWon()
    {
        Debug.Log("Stage Win");
        PlayerInput.instance.Disable();
    }

    public void StageLose()
    {
        Debug.Log("Stage Lose");
        PlayerInput.instance.Disable();
    }
}
