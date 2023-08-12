using System.Collections.Generic;
using UnityEngine;
namespace GeometryDash
{
    #region PlayerModeEunum

    // Disaridan erisim gerli oldugu icin class disinda tanimlandi
    public enum PlayerMode
    {
        Cube,
        Ship
    }
    #endregion

    [RequireComponent(typeof(PlayerAirController))]
    [RequireComponent(typeof(PlayerLandController))]
    [RequireComponent(typeof(CollisionDetection))]

    public class PlayerStateManager : MonoBehaviour
    {
        [Header("Land Player Variable")]
        [SerializeField] private GameObject _cubeVisual;
        private PlayerLandController _landController => GetComponent<PlayerLandController>();

        [Space(10)]
        [Header("Air Player Variable")]
        [SerializeField] private GameObject ShipVisual;
        private PlayerAirController _airController => GetComponent<PlayerAirController>();


        [Space(10)]
        [Header("Start Player Mode")]
        [Tooltip("Oyun basladiginda hangi modda baslayacagi buradan belirlenir")]
        [SerializeField] private PlayerMode StartPlayerMode;

        [HideInInspector] public PlayerMode CurrentPlayerMode;

        //yeni modlar eklenirse kontrol daha kolay olucaktir.
        //TODO: Mod sayisinin fazla olmasi durumunda Abstrack class kullanilarak Finite State Machine kurulmasi daha mantiklidir
        private Dictionary<PlayerMode, System.Action> playerModeAction;

        private void Awake()
        {
            playerModeAction = new Dictionary<PlayerMode, System.Action>
        {
            {PlayerMode.Cube, () => Change(false, true) },
            {PlayerMode.Ship, () => Change(true, false) }
        };

            SetState(StartPlayerMode);
        }

        public void ResetGameState(GameManager manager)
        {
            SetState(manager.GetResetMode());
        }
        public void SetState(PlayerMode newState)
        {
            CurrentPlayerMode = newState;
            if (playerModeAction.ContainsKey(CurrentPlayerMode))
            {
                playerModeAction[CurrentPlayerMode]?.Invoke();
                //change particle
            }
            else Debug.LogError("Unknown player mode: " + CurrentPlayerMode);
        }

        private void Change(bool air, bool land)
        {
            _cubeVisual.SetActive(land);
            _landController.enabled = land;

            ShipVisual.SetActive(air);
            _airController.enabled = air;
        }
    }
}