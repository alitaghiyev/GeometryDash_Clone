using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GeometryDash
{
    public class InputReader : MonoBehaviour, InputActions.IPlayerActions
    {
        /// <summary>
        /// For jumping only at the moment of clicking
        /// </summary>
        [HideInInspector]
        public event Action JumpEvent;

        /// <summary>
        /// Used for hold input; can be used for continuous jumping without waiting for new input when the cube is grounded
        /// </summary>
        [HideInInspector]
        public bool IsHolding { get; private set; }

        
        #region ENABLE AND DISABLE ACTION OBJECT
        private InputActions action;
        private void Start()
        {
            action = new InputActions();
            action.Player.SetCallbacks(this);
            action.Player.Enable();
        }
        private void OnDestroy()
        {
            action.Player.Disable();
        }
        #endregion ENABLE AND DISABLE ACTION OBJECT


        public void OnJumpHold(InputAction.CallbackContext context)
        {
            if (context.performed) // executed when the action is performed
            {
                IsHolding = true;
                JumpEvent?.Invoke();
            }
            else if (context.canceled) // executed when the action is canceled
            {
                IsHolding = false;
            }
            // or 
            // IsHolding = context.ReadValueAsButton();
        }
    }
}