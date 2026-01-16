using UnityEngine;
using UnityEngine.Serialization;

namespace Implementation.Core
{
    public class PlayerMovement : MonoBehaviour
    {
        [FormerlySerializedAs("controls")]
        public CharacterController charController;

        public float speed = 12f;

        [FormerlySerializedAs("grav")]
        public float gravity = -9.81f;

        [FormerlySerializedAs("jumph")]
        public float jumpHeight = 1f;

        [FormerlySerializedAs("groundcheck")]
        public Transform groundCheck;

        public float groundDistance = 0.4f;
        public LayerMask groundMask;

        private Vector3 _velocity;
        private bool _isGrounded;

        // Update is called once per frame
        private void Update()
        {
            UpdateLocation();
        }

        private void UpdateLocation()
        {
            _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }

            if (_velocity.x > 0 || _velocity.z > 0)
            {
            }

            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            var moveVector = transform.right * x + transform.forward * z;

            charController.Move(moveVector * (speed * Time.deltaTime));

            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            _velocity.y += gravity * Time.deltaTime;

            charController.Move(_velocity * Time.deltaTime);
        }
    }
}