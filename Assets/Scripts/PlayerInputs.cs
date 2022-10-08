using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    public PlayerAction playerInput;

    private Rigidbody2D rb;

    [Header("Movement")]
    public float speed = 1;

    public int tapDirection = 0;

    #region Singleton
    private static PlayerInputs _instance;
    public static PlayerInputs instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("PlayerInputs is null");
            }
            return _instance;
        }
    }
    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;

        playerInput = new PlayerAction();
        rb = GetComponent<Rigidbody2D>();

        InitializePlayerInputCallbacks();
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(speed * tapDirection, 0));
    }

    #region Callbacks
    private void InitializePlayerInputCallbacks()
    {
        playerInput.PlayerControls.Enable();
        playerInput.PlayerControls.Tap1.started += OnTapLeft;
        playerInput.PlayerControls.Tap2.started += OnTapRight;
        playerInput.PlayerControls.Tap1.performed += OnTapCanceled;
        playerInput.PlayerControls.Tap2.performed += OnTapCanceled;
        playerInput.PlayerControls.Tap1.canceled += OnTapCanceled;
        playerInput.PlayerControls.Tap2.canceled += OnTapCanceled;
    }
    #endregion

    #region Methods
    private void OnTapLeft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            tapDirection = -1;
            Debug.Log("tapped");
        }
    }
    private void OnTapRight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            tapDirection = 1;
            Debug.Log("tapped");
        }
    }
    private void OnTapCanceled(InputAction.CallbackContext context)
    {
        tapDirection = 0;
    }
    #endregion
}
