using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GeometryDash
{
    public class InputReader : MonoBehaviour, InputActions.IPlayerActions
    {
        /// <summary>
        /// Sadece tiklama aninda ziplama icin
        /// </summary>
        [HideInInspector]
        public event Action JumpEvent;

        /// <summary>
        /// Hold inputu icin kullanilir, bunun disinda isground olmasi halinde kupun yeni input beklemeden ziplamaya devam etmesi icin kullanila bilir
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
            if (context.performed) //eylem tetiklendiginde calisir
            {
                IsHolding = true;
                JumpEvent?.Invoke();
            }
            else if (context.canceled)//eylem iptal edildiginde calisir
            {
                IsHolding = false;
            }
            //ve ya 
            //IsHolding = context.ReadValueAsButton();
        }
    }
}