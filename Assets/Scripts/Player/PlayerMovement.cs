using Core;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private bool _isMotionApproved;
        private const float ForceMultiplier = 50;
        
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

            if (InputManager.TouchHold())
            {
                _rigidbody.AddForce(Vector2.up * ForceMultiplier);
            }
        }
    }
}