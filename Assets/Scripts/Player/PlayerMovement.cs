using Core;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float forceMultiplier = 30;

        private Rigidbody2D _rigidbody;
        private bool _isMotionApproved;
        private bool _addForce;

        public void Init()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _isMotionApproved = false;
            
            StopMotion();
        }

        public void ApproveMotion()
        {
            _rigidbody.simulated = true;
            _rigidbody.isKinematic = false;

            _isMotionApproved = true;
        }

        public void StopMotion()
        {
            _rigidbody.simulated = false;
            _rigidbody.isKinematic = true;
        }

        private void Update()
        {
            if (!_isMotionApproved) return;

            if (InputManager.TouchBegin() || InputManager.TouchHold())
            {
                _addForce = true;
            }

            if (InputManager.TouchRelease())
                _addForce = false;
        }

        private void FixedUpdate()
        {
            if (!_isMotionApproved) return;

            if (_addForce)
            {
                _rigidbody.AddForce(Vector2.up * forceMultiplier);
            }
        }
    }
}