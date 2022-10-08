using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public BeatInputAction beatInput;

    public static PlayerInput instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("There is more than one PlayerInput in this scene!");
        }
        else
        {
            instance = this;
        }

        beatInput = new BeatInputAction();

        InitializePlayerInputCallbacks();
    }

    #region Callbacks
    private void InitializePlayerInputCallbacks()
    {
        beatInput.controls.Enable();
        beatInput.controls.Input1.performed += OnInput1;
        beatInput.controls.Input2.performed += OnInput2;
        beatInput.controls.Input3.performed += OnInput3;
        beatInput.controls.Input4.performed += OnInput4;
    }
    #endregion

    #region Methods
    private void OnInput1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

        }
    }
    private void OnInput2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

        }
    }
    private void OnInput3(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

        }
    }
    private void OnInput4(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

        }
    }

    public void Disable()
    {
        beatInput.Disable();
    }
    #endregion

    #region Input Triggered
    public int inputTriggered()
    {
        if (beatInput.controls.Input1.triggered) return 1;
        else if (beatInput.controls.Input2.triggered) return 2;
        else if (beatInput.controls.Input3.triggered) return 3;
        else if (beatInput.controls.Input4.triggered) return 4;

        return 0;
    }
    #endregion
}
