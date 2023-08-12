using UnityEngine;

namespace GeometryDash.Character
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float _playerSpeed = 8;
        private Rigidbody2D _rb => GetComponent<Rigidbody2D>();
        private void FixedUpdate()
        {
            MoveForward();
        }
        private void MoveForward()
        {
            _rb.velocity = new Vector2(_playerSpeed, _rb.velocity.y);
        }

    }
}
