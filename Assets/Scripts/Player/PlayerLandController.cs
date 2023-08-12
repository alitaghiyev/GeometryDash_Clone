using UnityEngine;
namespace GeometryDash
{
    public class PlayerLandController : MonoBehaviour, ICharacter
    {
        #region Variables
        [Header("Movement and Animation Variable")]
        [SerializeField] private float _playerJumpForce;
        [SerializeField] private float _gravityScale;
        [SerializeField] private float _spriteRotationSpeed = 4f;

        [Space(10)]
        [Header("Resources")]
        [SerializeField] private Transform _playerSprite;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private CollisionDetection _collisionDetection;
        private Rigidbody2D _rb => GetComponent<Rigidbody2D>();

        #endregion

        #region Subscribe Event
        private void OnEnable()
        {
            _rb.gravityScale = _gravityScale;
            _inputReader.JumpEvent += PerformAction;
        }  

        private void OnDisable() => _inputReader.JumpEvent -= PerformAction;
        #endregion


        void Update() => Animate();


        public void PerformAction()
        {
            if (_collisionDetection.IsGround)
            {
                _rb.velocity = Vector2.zero;
                _rb.AddForce(Vector2.up * _playerJumpForce, ForceMode2D.Impulse);
            }
        }
        public void Animate()
        {
            if (_collisionDetection.IsGround)
            {
                Vector3 spriteRotation = _playerSprite.rotation.eulerAngles;
                spriteRotation.z = Mathf.Round(spriteRotation.z / 90) * 90;
                _playerSprite.rotation = Quaternion.Euler(spriteRotation);
            }
            else
            {
                _playerSprite.Rotate(Vector3.back * _spriteRotationSpeed);
            }
        }
    }
}