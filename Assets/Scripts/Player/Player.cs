using UnityEngine;
using System;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class Player : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private Vector3 _position;
        public event Action PlayerCollisionDetected;
        
        public void Init()
        {
            _playerMovement = gameObject.GetComponent<PlayerMovement>();
            _playerMovement.Init();
            _position = transform.position;
        }

        public void SetPlayerReady()
        {
            _playerMovement.ApproveMotion();
        }

        public void StopPlayer()
        {
            _playerMovement.StopMotion();
        }

        public void Restart()
        {
            transform.position = _position;
        }
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            CollisionDetected();
        }

        private void CollisionDetected()
        {
            PlayerCollisionDetected?.Invoke();  
        }
    }
}