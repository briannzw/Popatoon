using UnityEngine;
using UnityEngine.UI;

public class BeatManager : MonoBehaviour
{
    [Header("Beat Settings")]
    public int beatCount = 4;
    public int beatIdleCount = 4;
    public int beatFalseIdleCount = 2;

    private int _beatIdleCount;

    [SerializeField] private int beatPerMinute = 60;
    private float timer = 0.0f;

    private int[] commandNum;
    private int beatNum = 0;
    private int inputNum = 0;
    private int comboNum = 0;

    private bool isIdle = false;

    private BeatUI beatUI;

    private void Start()
    {
        _beatIdleCount = beatIdleCount;
        commandNum = new int[beatCount];

        beatUI = GetComponent<BeatUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= (1.0f / (beatPerMinute / 60)))
        {
            if (isIdle)
            {
                if (_beatIdleCount <= 0)
                {
                    isIdle = false;
                    ResetCombo();
                    ResetUI();
                    _beatIdleCount = beatIdleCount;
                }

                _beatIdleCount--;
                timer = 0.0f;
                return;
            }

            if (beatNum != 0)
            {
                UpdateBeatTimer();
                timer = 0.0f;
            }
            else
            {
                if(commandNum[0] != 0)
                {
                    ResetCombo();
                    ResetUI();
                }
            }
        }

        if(beatNum == 0 && !isIdle)
        {
            beatNum = CheckInput();
        }
    }

    void UpdateBeatTimer()
    {
        if (comboNum < beatCount)
        {
            commandNum[comboNum] = beatNum;
            beatUI.beatSlider[comboNum].color = beatUI.beatColor[beatNum - 1];
            comboNum++;
            beatNum = 0;

            if (comboNum == beatCount)
            {
                if (CheckCombo())
                {
                    isIdle = true;
                    _beatIdleCount = beatIdleCount;
                }
                else
                {
                    isIdle = true;
                    ResetCombo();
                    _beatIdleCount = beatFalseIdleCount;
                    FailUI();
                }
            }
        }
        else comboNum = 0;
    }

    #region Input
    int CheckInput()
    {
        inputNum = PlayerInput.instance.inputTriggered();
        if (inputNum != 0)
        {
            return inputNum;
            //timer = 0.0f;
        }

        return 0;
    }
    #endregion

    #region Combo
    bool CheckCombo()
    {
        if (CharaManager.instance.Command(commandNum))
        {
            return true;
        }
        
        // No valid command found
        return false;
    }

    void ResetCombo()
    {
        for (int i = 0; i < beatCount; i++)
        {
            commandNum[i] = 0;
        }
        comboNum = 0;
    }

    void ResetUI()
    {

        foreach (Image img in beatUI.beatSlider)
        {
            if (img != null)
            {
                img.color = Color.white;
            }
        }
    }

    void FailUI()
    {
        foreach (Image img in beatUI.beatSlider)
        {
            if (img != null)
            {
                img.color = beatUI.failColor;
            }
        }
    }
    #endregion
}
