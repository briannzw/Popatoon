using System.Collections;
using System.Linq;
using UnityEngine;

public class CharaManager : MonoBehaviour
{
    public Character[] characters;

    public static CharaManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("There's more than one CharaManager in this scene!");
        }
        else
        {
            instance = this;
        }

        characters = GetComponentsInChildren<Character>();
        StageManager.instance.PlayerSpawn(characters.Length);
    }

    #region Commands
    // if there's valid command, return true. Otherwise, false.
    public bool Command(int[] commandNum)
    {
        bool canCommand = false;
        foreach(Character chara in characters)
        {
            foreach(CommandSO command in chara.commands)
            {
                if (commandNum.SequenceEqual(command.commandNum))
                {
                    if (chara.DoCommand(command))
                    {
                        canCommand = true;
                    }
                }
            }
        }
        return canCommand;
    }
    #endregion

    public void Win()
    {
        foreach (Character chara in characters)
        {
            chara.SetCharaAnimationState(CharaState.Taunt);
        }
    }
}
