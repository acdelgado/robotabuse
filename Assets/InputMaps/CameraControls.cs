//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputMaps/CameraControls.inputactions
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

public partial class @CameraControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CameraControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CameraControls"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""0f3f71df-3fed-4718-8e28-649bcf8618f3"",
            ""actions"": [
                {
                    ""name"": ""RotateCameraHorizontal"",
                    ""type"": ""Button"",
                    ""id"": ""b5d76f93-6642-4a1a-87b8-971475e5fa49"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateCameraVertical"",
                    ""type"": ""Button"",
                    ""id"": ""4e5ef50a-46ac-48bf-9638-5f2ba3c71e53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""a7724b46-9f37-41a4-ac21-1b43009d98ef"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCameraHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""862eaca2-1ca3-4ef7-8cbf-1da11d8b3e01"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""RotateCameraHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f3110e89-f802-4238-bcfb-c8cd2e596ce8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""RotateCameraHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""616e2dbe-17d0-457f-8f3f-e7a4347dcd76"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCameraVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9b9019b0-a1b3-4b29-b7fb-4f666a6f2218"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""RotateCameraVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""107e0c97-351f-447e-be8e-75614e2d33a1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""RotateCameraVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Default
        m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
        m_Default_RotateCameraHorizontal = m_Default.FindAction("RotateCameraHorizontal", throwIfNotFound: true);
        m_Default_RotateCameraVertical = m_Default.FindAction("RotateCameraVertical", throwIfNotFound: true);
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

    // Default
    private readonly InputActionMap m_Default;
    private List<IDefaultActions> m_DefaultActionsCallbackInterfaces = new List<IDefaultActions>();
    private readonly InputAction m_Default_RotateCameraHorizontal;
    private readonly InputAction m_Default_RotateCameraVertical;
    public struct DefaultActions
    {
        private @CameraControls m_Wrapper;
        public DefaultActions(@CameraControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @RotateCameraHorizontal => m_Wrapper.m_Default_RotateCameraHorizontal;
        public InputAction @RotateCameraVertical => m_Wrapper.m_Default_RotateCameraVertical;
        public InputActionMap Get() { return m_Wrapper.m_Default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void AddCallbacks(IDefaultActions instance)
        {
            if (instance == null || m_Wrapper.m_DefaultActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DefaultActionsCallbackInterfaces.Add(instance);
            @RotateCameraHorizontal.started += instance.OnRotateCameraHorizontal;
            @RotateCameraHorizontal.performed += instance.OnRotateCameraHorizontal;
            @RotateCameraHorizontal.canceled += instance.OnRotateCameraHorizontal;
            @RotateCameraVertical.started += instance.OnRotateCameraVertical;
            @RotateCameraVertical.performed += instance.OnRotateCameraVertical;
            @RotateCameraVertical.canceled += instance.OnRotateCameraVertical;
        }

        private void UnregisterCallbacks(IDefaultActions instance)
        {
            @RotateCameraHorizontal.started -= instance.OnRotateCameraHorizontal;
            @RotateCameraHorizontal.performed -= instance.OnRotateCameraHorizontal;
            @RotateCameraHorizontal.canceled -= instance.OnRotateCameraHorizontal;
            @RotateCameraVertical.started -= instance.OnRotateCameraVertical;
            @RotateCameraVertical.performed -= instance.OnRotateCameraVertical;
            @RotateCameraVertical.canceled -= instance.OnRotateCameraVertical;
        }

        public void RemoveCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDefaultActions instance)
        {
            foreach (var item in m_Wrapper.m_DefaultActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DefaultActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DefaultActions @Default => new DefaultActions(this);
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    public interface IDefaultActions
    {
        void OnRotateCameraHorizontal(InputAction.CallbackContext context);
        void OnRotateCameraVertical(InputAction.CallbackContext context);
    }
}