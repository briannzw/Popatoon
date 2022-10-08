using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BeatManager_old : MonoBehaviour
{
    public TMP_Text timeLabel;
    public Slider[] beatSlider;
    public BeatSO[] beatSO;
    //public Color[] beatColors;

    [SerializeField] private int beatPerMinute = 60;

    private int beatTimer = 0;
    private float timer = 0.0f;
    private bool isIdle = false;

    //Input
    public BeatInputAction beatAction;
    private int tapInput = 0;

    //Beat
    private AudioSource audioSource;
    private BeatSO[] currentBeat;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        beatAction = new BeatInputAction();
        beatAction.controls.Enable();
        beatTimer = beatSlider.Length - 1;
        currentBeat = new BeatSO[beatSlider.Length];
        HideBeat();
        RandomBeat();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= (1.0f / (beatPerMinute / 60)))
        {
            UpdateBeatTimer();
            timer = 0.0f;
        }
        if (!isIdle)
        {
            if (tapInput == 0)
            {
                tapInput = CheckInput();
                if (tapInput != 0) CheckInputColor();
            }

            beatSlider[beatTimer].value += Time.deltaTime * (beatPerMinute / 60);
        }
    }

    #region Methods
    void UpdateBeatTimer()
    {
        tapInput = 0;

        beatTimer = (beatTimer + 1) % beatSlider.Length;
        if (beatTimer == 0)
        {
            if (!isIdle)
            {
                HideBeat();
                RandomBeat();
                isIdle = true;
            }
            else
            {
                ResetBeat();
                InitializeBeat();
                isIdle = false;
            }
        }
        beatSlider[beatTimer].fillRect.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, .3f);
        timeLabel.text = beatTimer.ToString();

        if (isIdle) PlayBeatClip();
    }

    void RandomBeat()
    {
        for (int i = 0; i < beatSlider.Length; i++)
        {
            currentBeat[i] = beatSO[Random.Range(0, beatSO.Length)];
        }
    }

    void InitializeBeat()
    {
        for (int i = 0; i < beatSlider.Length; i++)
        {
            Slider beat = beatSlider[i];
            beat.gameObject.SetActive(true);
            beat.GetComponentInChildren<Image>().color = currentBeat[i].beatColor;
        }
    }

    void ResetBeat()
    {
        foreach (Slider beat in beatSlider)
        {
            beat.fillRect.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0f);
            beat.value = 0;
        }
    }
    
    void HideBeat()
    {
        foreach (Slider beat in beatSlider)
        {
            beat.gameObject.SetActive(false);
        }
    }
    #endregion

    #region Inputs
    int CheckInput()
    {
        if (beatAction.controls.Input1.triggered)
        {
            //2 Keys and 4 Keys
            return 1;
        }
        if (beatAction.controls.Input2.triggered)
        {
            //4 Keys
            if(beatSO.Length == 4)
            {
                return 2;
            }

            //2 Keys
            return 1;
        }
        if (beatAction.controls.Input3.triggered)
        {
            //4 Keys
            if (beatSO.Length == 4)
            {
                return 3;
            }

            //2 Keys
            return 2;
        }
        if (beatAction.controls.Input4.triggered)
        {
            //4 Keys
            if (beatSO.Length == 4)
            {
                return 4;
            }

            //2 Keys
            return 2;
        }

        return 0;
    }

    void CheckInputColor()
    {
        if(beatSlider[beatTimer].GetComponentInChildren<Image>().color == beatSO[tapInput - 1].beatColor)
        {
            beatSlider[beatTimer].fillRect.gameObject.GetComponent<Image>().color = Color.green;
        }
        else
        {
            beatSlider[beatTimer].fillRect.gameObject.GetComponent<Image>().color = Color.red;
        }
    }
    #endregion

    #region Beat Sound
    void PlayBeatClip()
    {
        audioSource.clip = currentBeat[beatTimer].beatSoundFile;
        audioSource.Play();
    }
    #endregion
}
