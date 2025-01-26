//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Recursos/PlayerControllerMap.inputactions
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

public partial class @PlayerControllerMap: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControllerMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControllerMap"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""b680f53a-0f82-43f3-a68e-b833ebf3a731"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""89b9620e-a425-498d-8fb7-3c945f849cfb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""59c5dcf5-e3d6-4b45-99d5-6aac788fab44"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""7c7ff0bd-2714-45e7-b263-cb725576a390"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""6b002693-be25-4c16-ba9c-6365f446b3d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""6a00975b-ebd3-42e5-89c1-4dab3bb10bc3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c05bb376-d220-4ed1-bf4a-d104a29665e1"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""b221dc37-c8c0-4cf9-8a16-aa1e8843565d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""29a0a6fe-2ebf-4086-bdc3-ca1dedfee0eb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""88bb63ff-8395-43a6-804f-84407226ed93"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8c0be0db-ae34-4748-ab41-9f3264ab82c5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9a8e26df-8578-4147-867a-e255021d415d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""da667c56-988e-443a-8c50-d523e78b1202"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da15d453-2664-4299-b006-2fada5630992"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5141929f-ff72-4827-bf96-7644d77e03a8"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f0bec56-0c4c-4c3e-b80d-71c5082579ec"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee281074-071a-4cf3-9e4f-e852037453f0"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c703a9b3-c813-42a4-9b56-c9237876f056"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8127a8a-08ff-41b1-94b6-dc9a49f32a63"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuController"",
            ""id"": ""5dc38043-fbb7-45aa-857b-335a2676c3f5"",
            ""actions"": [
                {
                    ""name"": ""NextChar"",
                    ""type"": ""Button"",
                    ""id"": ""cbb5966a-04c4-4dbf-bd4d-e64f37715ed9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PrevChar"",
                    ""type"": ""Button"",
                    ""id"": ""b359fd3e-6c55-4233-ad91-f3d2d0402bed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""86131536-acf3-4aec-9a3d-14f7aec721f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""97398a81-b6bd-48cd-a9cc-9dede4c42b01"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextChar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b02a9fd-3970-4812-9ee9-85089a972d1e"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextChar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b80b59f8-f583-4f76-822a-c68a00d2bce2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrevChar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ff96b53-079b-47c9-939b-1a3ddba1570a"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrevChar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8980e1b5-3655-498d-8208-c7a9790b1d62"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f3e6de7-fca3-476c-832d-f46419943137"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Trapped"",
            ""id"": ""c8797f9b-5fe4-4e7f-9578-ea671ceb7be9"",
            ""actions"": [
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""35f4005b-449e-4293-9913-7abfd6358e13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d1187e4a-579d-4c16-822d-c95881f297e1"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6dbff88a-6a8d-477c-a8c2-ef71057c16d9"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_Move = m_GamePlay.FindAction("Move", throwIfNotFound: true);
        m_GamePlay_Jump = m_GamePlay.FindAction("Jump", throwIfNotFound: true);
        m_GamePlay_Dash = m_GamePlay.FindAction("Dash", throwIfNotFound: true);
        m_GamePlay_Shoot = m_GamePlay.FindAction("Shoot", throwIfNotFound: true);
        m_GamePlay_Escape = m_GamePlay.FindAction("Escape", throwIfNotFound: true);
        // MenuController
        m_MenuController = asset.FindActionMap("MenuController", throwIfNotFound: true);
        m_MenuController_NextChar = m_MenuController.FindAction("NextChar", throwIfNotFound: true);
        m_MenuController_PrevChar = m_MenuController.FindAction("PrevChar", throwIfNotFound: true);
        m_MenuController_Confirm = m_MenuController.FindAction("Confirm", throwIfNotFound: true);
        // Trapped
        m_Trapped = asset.FindActionMap("Trapped", throwIfNotFound: true);
        m_Trapped_Escape = m_Trapped.FindAction("Escape", throwIfNotFound: true);
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

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private List<IGamePlayActions> m_GamePlayActionsCallbackInterfaces = new List<IGamePlayActions>();
    private readonly InputAction m_GamePlay_Move;
    private readonly InputAction m_GamePlay_Jump;
    private readonly InputAction m_GamePlay_Dash;
    private readonly InputAction m_GamePlay_Shoot;
    private readonly InputAction m_GamePlay_Escape;
    public struct GamePlayActions
    {
        private @PlayerControllerMap m_Wrapper;
        public GamePlayActions(@PlayerControllerMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_GamePlay_Move;
        public InputAction @Jump => m_Wrapper.m_GamePlay_Jump;
        public InputAction @Dash => m_Wrapper.m_GamePlay_Dash;
        public InputAction @Shoot => m_Wrapper.m_GamePlay_Shoot;
        public InputAction @Escape => m_Wrapper.m_GamePlay_Escape;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void AddCallbacks(IGamePlayActions instance)
        {
            if (instance == null || m_Wrapper.m_GamePlayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GamePlayActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
            @Escape.started += instance.OnEscape;
            @Escape.performed += instance.OnEscape;
            @Escape.canceled += instance.OnEscape;
        }

        private void UnregisterCallbacks(IGamePlayActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
            @Escape.started -= instance.OnEscape;
            @Escape.performed -= instance.OnEscape;
            @Escape.canceled -= instance.OnEscape;
        }

        public void RemoveCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGamePlayActions instance)
        {
            foreach (var item in m_Wrapper.m_GamePlayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GamePlayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);

    // MenuController
    private readonly InputActionMap m_MenuController;
    private List<IMenuControllerActions> m_MenuControllerActionsCallbackInterfaces = new List<IMenuControllerActions>();
    private readonly InputAction m_MenuController_NextChar;
    private readonly InputAction m_MenuController_PrevChar;
    private readonly InputAction m_MenuController_Confirm;
    public struct MenuControllerActions
    {
        private @PlayerControllerMap m_Wrapper;
        public MenuControllerActions(@PlayerControllerMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @NextChar => m_Wrapper.m_MenuController_NextChar;
        public InputAction @PrevChar => m_Wrapper.m_MenuController_PrevChar;
        public InputAction @Confirm => m_Wrapper.m_MenuController_Confirm;
        public InputActionMap Get() { return m_Wrapper.m_MenuController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuControllerActions set) { return set.Get(); }
        public void AddCallbacks(IMenuControllerActions instance)
        {
            if (instance == null || m_Wrapper.m_MenuControllerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MenuControllerActionsCallbackInterfaces.Add(instance);
            @NextChar.started += instance.OnNextChar;
            @NextChar.performed += instance.OnNextChar;
            @NextChar.canceled += instance.OnNextChar;
            @PrevChar.started += instance.OnPrevChar;
            @PrevChar.performed += instance.OnPrevChar;
            @PrevChar.canceled += instance.OnPrevChar;
            @Confirm.started += instance.OnConfirm;
            @Confirm.performed += instance.OnConfirm;
            @Confirm.canceled += instance.OnConfirm;
        }

        private void UnregisterCallbacks(IMenuControllerActions instance)
        {
            @NextChar.started -= instance.OnNextChar;
            @NextChar.performed -= instance.OnNextChar;
            @NextChar.canceled -= instance.OnNextChar;
            @PrevChar.started -= instance.OnPrevChar;
            @PrevChar.performed -= instance.OnPrevChar;
            @PrevChar.canceled -= instance.OnPrevChar;
            @Confirm.started -= instance.OnConfirm;
            @Confirm.performed -= instance.OnConfirm;
            @Confirm.canceled -= instance.OnConfirm;
        }

        public void RemoveCallbacks(IMenuControllerActions instance)
        {
            if (m_Wrapper.m_MenuControllerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMenuControllerActions instance)
        {
            foreach (var item in m_Wrapper.m_MenuControllerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MenuControllerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MenuControllerActions @MenuController => new MenuControllerActions(this);

    // Trapped
    private readonly InputActionMap m_Trapped;
    private List<ITrappedActions> m_TrappedActionsCallbackInterfaces = new List<ITrappedActions>();
    private readonly InputAction m_Trapped_Escape;
    public struct TrappedActions
    {
        private @PlayerControllerMap m_Wrapper;
        public TrappedActions(@PlayerControllerMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Escape => m_Wrapper.m_Trapped_Escape;
        public InputActionMap Get() { return m_Wrapper.m_Trapped; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TrappedActions set) { return set.Get(); }
        public void AddCallbacks(ITrappedActions instance)
        {
            if (instance == null || m_Wrapper.m_TrappedActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_TrappedActionsCallbackInterfaces.Add(instance);
            @Escape.started += instance.OnEscape;
            @Escape.performed += instance.OnEscape;
            @Escape.canceled += instance.OnEscape;
        }

        private void UnregisterCallbacks(ITrappedActions instance)
        {
            @Escape.started -= instance.OnEscape;
            @Escape.performed -= instance.OnEscape;
            @Escape.canceled -= instance.OnEscape;
        }

        public void RemoveCallbacks(ITrappedActions instance)
        {
            if (m_Wrapper.m_TrappedActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ITrappedActions instance)
        {
            foreach (var item in m_Wrapper.m_TrappedActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_TrappedActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public TrappedActions @Trapped => new TrappedActions(this);
    public interface IGamePlayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
    }
    public interface IMenuControllerActions
    {
        void OnNextChar(InputAction.CallbackContext context);
        void OnPrevChar(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
    }
    public interface ITrappedActions
    {
        void OnEscape(InputAction.CallbackContext context);
    }
}
