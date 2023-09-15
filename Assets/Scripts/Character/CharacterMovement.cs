using UnityEngine;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [Header("Physics")]
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpForce;
        
        private Rigidbody _rigidbody;
        private bool _isGrounded;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _isGrounded = true;
        }

        private void Update()
        {
            this.Jump();
        }

        private void FixedUpdate()
        {
            this.Movement();
        }

        private void Movement()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * _moveSpeed * Time.fixedDeltaTime;
            Vector3 newPosition = _rigidbody.position + _rigidbody.rotation * movement;

            _rigidbody.MovePosition(newPosition);
        }

        #region Jump

        private void Jump()
        {
            if (!_isGrounded || !Input.GetKeyDown(KeyCode.Space)) return;

            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.contacts.Length <= 0) return;

            foreach (ContactPoint contact in collision.contacts)
            {
                if (Vector3.Dot(contact.normal, Vector3.up) > 0.7f)
                    _isGrounded = true;
            }
        }

        #endregion
    }
}