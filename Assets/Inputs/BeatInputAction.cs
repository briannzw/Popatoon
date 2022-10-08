//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Inputs/BeatInputAction.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @BeatInputAction : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @BeatInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BeatInputAction"",
    ""maps"": [
        {
            ""name"": ""controls"",
            ""id"": ""119edd25-41a1-457c-a83b-5e4ccb45483b"",
            ""actions"": [
                {
                    ""name"": ""Input 1"",
                    ""type"": ""Button"",
                    ""id"": ""db9fa5e2-18ec-461d-bf21-737e28b2216d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Input 2"",
                    ""type"": ""Button"",
                    ""id"": ""6bffbb9a-e082-4b71-954c-3387e9f62a24"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Input 3"",
                    ""type"": ""Button"",
                    ""id"": ""70488e22-b10f-423a-a043-b99b6d3753c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Input 4"",
                    ""type"": ""Button"",
                    ""id"": ""1c42d6ef-242f-446e-bb2b-6f1a8da2217a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5375a542-a15e-4bf6-832b-f7f5beb48283"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Input 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23804761-4a28-425d-bf59-d9756e2ed3b9"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Input 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bd3d979-f45d-4e6c-babe-041694474a0b"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Input 3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11bff206-3dac-4642-8385-f73a3f8bc8f0"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Input 4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // controls
        m_controls = asset.FindActionMap("controls", throwIfNotFound: true);
        m_controls_Input1 = m_controls.FindAction("Input 1", throwIfNotFound: true);
        m_controls_Input2 = m_controls.FindAction("Input 2", throwIfNotFound: true);
        m_controls_Input3 = m_controls.FindAction("Input 3", throwIfNotFound: true);
        m_controls_Input4 = m_controls.FindAction("Input 4", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // controls
    private readonly InputActionMap m_controls;
    private IControlsActions m_ControlsActionsCallbackInterface;
    private readonly InputAction m_controls_Input1;
    private readonly InputAction m_controls_Input2;
    private readonly InputAction m_controls_Input3;
    private readonly InputAction m_controls_Input4;
    public struct ControlsActions
    {
        private @BeatInputAction m_Wrapper;
        public ControlsActions(@BeatInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Input1 => m_Wrapper.m_controls_Input1;
        public InputAction @Input2 => m_Wrapper.m_controls_Input2;
        public InputAction @Input3 => m_Wrapper.m_controls_Input3;
        public InputAction @Input4 => m_Wrapper.m_controls_Input4;
        public InputActionMap Get() { return m_Wrapper.m_controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
        public void SetCallbacks(IControlsActions instance)
        {
            if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
            {
                @Input1.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInput1;
                @Input1.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInput1;
                @Input1.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInput1;
                @Input2.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInput2;
                @Input2.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInput2;
                @Input2.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInput2;
                @Input3.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInput3;
                @Input3.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInput3;
                @Input3.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInput3;
                @Input4.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInput4;
                @Input4.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInput4;
                @Input4.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInput4;
            }
            m_Wrapper.m_ControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Input1.started += instance.OnInput1;
                @Input1.performed += instance.OnInput1;
                @Input1.canceled += instance.OnInput1;
                @Input2.started += instance.OnInput2;
                @Input2.performed += instance.OnInput2;
                @Input2.canceled += instance.OnInput2;
                @Input3.started += instance.OnInput3;
                @Input3.performed += instance.OnInput3;
                @Input3.canceled += instance.OnInput3;
                @Input4.started += instance.OnInput4;
                @Input4.performed += instance.OnInput4;
                @Input4.canceled += instance.OnInput4;
            }
        }
    }
    public ControlsActions @controls => new ControlsActions(this);
    public interface IControlsActions
    {
        void OnInput1(InputAction.CallbackContext context);
        void OnInput2(InputAction.CallbackContext context);
        void OnInput3(InputAction.CallbackContext context);
        void OnInput4(InputAction.CallbackContext context);
    }
}
