using UnityEngine;

[CreateAssetMenu(menuName = "Character Command/CommandSO")]
public class CommandSO : ScriptableObject
{
    [SerializeField] public int[] commandNum;
    [SerializeField] public CharaState state;
    [SerializeField] public int index;
}
