using UnityEngine;
namespace GeometryDash
{
    public class PlayerAirController : MonoBehaviour, ICharacter
    {
        #region Variables
        [Header("Movement and Animation Variable")]
        [SerializeField] private float _upwardGravityScale = 4;
        [SerializeField] private float _downwardGravityScale = 3;
        [SerializeField] private float _spriteRotationSpeed = 2f;
        [SerializeField] private float _spriteRotationLimitAngle = 45f;

        [Space(10)]
        [Header("Resources")]
        [SerializeField] private Transform _playerSprite;
        [SerializeField] private InputReader _inputReader;

        private Rigidbody2D _rb => GetComponent<Rigidbody2D>();
        #endregion

        private void Awake() => _rb.gravityScale = _downwardGravityScale;

        private void Update()
        {
            PerformAction();
            Animate();
        }
  
        public void PerformAction()
        {
            _rb.gravityScale = CalculateGraivty();
        }

        public void Animate()
        {
            float angle = Mathf.Clamp(_rb.velocity.y * _spriteRotationSpeed, -_spriteRotationLimitAngle, _spriteRotationLimitAngle);
            _playerSprite.rotation = Quaternion.Euler(0, 0, angle);
        }

        private float CalculateGraivty()
        {
            return (_inputReader.IsHolding)? -_upwardGravityScale: _downwardGravityScale;
        }
    }
}