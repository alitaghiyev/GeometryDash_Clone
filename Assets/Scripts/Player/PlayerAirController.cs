using UnityEngine;
namespace GeometryDash
{
    public class PlayerAirController : MonoBehaviour, ICharacter
    {
        #region Variables
        [Header("Movement and Animation Variable")]
        [SerializeField] private float _upwardGravityScale = 4;
        [SerializeField] private float _downwardGravityScale = 3;
        [Space(5)]
        [SerializeField] private float _spriteRotationSpeed = 2f;
        [SerializeField] private float _spriteRotationLimitAngle = 45f;

        [Space(10)]
        [Header("Resources")]
        [SerializeField] private Transform _playerSprite;
        [SerializeField] private InputReader _inputReader;

        private Rigidbody2D _playerRb => GetComponent<Rigidbody2D>();
        #endregion

        private void Awake() => _playerRb.gravityScale = _downwardGravityScale;
        private void Update()
        {
            PerformAction();
            Animate();
        }
        public void PerformAction()
        {
            _playerRb.gravityScale = CalculateGravity();
        }

        public void Animate()
        {
            var angle = Mathf.Clamp(_playerRb.velocity.y * _spriteRotationSpeed,
                -_spriteRotationLimitAngle, 
                _spriteRotationLimitAngle);
            _playerSprite.rotation = Quaternion.Euler(0, 0, angle);
        }

        private float CalculateGravity()
        {
            return (_inputReader.IsHolding)? -_upwardGravityScale: _downwardGravityScale;
        }
    }
}