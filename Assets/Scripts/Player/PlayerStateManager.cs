using System;
using UnityEngine;
using System.Collections.Generic;

namespace GeometryDash
{
    #region PlayerModeEunum
    public enum PlayerMode
    {
        Cube,
        Ship
    }
    [Serializable]
    public struct PlayerModeConfig
    {
        public PlayerMode mode;
        public GameObject visual;
        public MonoBehaviour controller;
    }
    #endregion

    [RequireComponent(typeof(PlayerAirController))]
    [RequireComponent(typeof(PlayerLandController))]
    [RequireComponent(typeof(CollisionDetection))]
    public class PlayerStateManager : MonoBehaviour
    {
        [Header("Player Modes")]
        [SerializeField] private PlayerModeConfig[] playerModes;
    
        [Header("Start Player Mode")]
        [SerializeField] private PlayerMode startPlayerMode;
        [HideInInspector] public PlayerMode currentPlayerMode;
    
        private Dictionary<PlayerMode, Action> _playerModeActions;

        private void Awake()
        {
            _playerModeActions = new Dictionary<PlayerMode, Action>();
            foreach (var modeConfig in playerModes)
            {
                _playerModeActions[modeConfig.mode] = () => ChangeMode(modeConfig);
            }
            ResetGameState();
        }
        public void SetState(PlayerMode newState)
        {
            currentPlayerMode = newState;
            if (_playerModeActions.ContainsKey(currentPlayerMode))
            {
                _playerModeActions[currentPlayerMode]?.Invoke();
            }
            else
                Debug.LogError("Unknown player mode: " + currentPlayerMode);
        }
        private void ChangeMode(PlayerModeConfig config)
        {
            foreach (var modeConfig in playerModes)
            {
                modeConfig.visual.SetActive(modeConfig.mode == config.mode);
                modeConfig.controller.enabled = (modeConfig.mode == config.mode);
            }
        }
        public void ResetGameState()=>SetState(startPlayerMode);
    }
}