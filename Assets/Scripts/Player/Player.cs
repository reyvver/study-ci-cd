using UnityEngine;
using System;
using Core;

namespace Player
{    
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerMovement))]
    public class Player : MonoBehaviour
    {
        private PlayerData _playerData;
        private PlayerMovement _playerMovement;
        private Vector3 _position;
        
        public event Action PlayerCollisionDetected;
        public event Action<int> PlayerCountUpdated;
        public event Action<int> PlayerMaxCountUpdated;

        
        public void Init()
        {
            _playerMovement = gameObject.GetComponent<PlayerMovement>();
            _playerMovement.Init();
            _position = transform.position;
            
            _playerData = new PlayerData();
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
            CheckPlayerCount();
        }

        private void CheckPlayerCount()
        {
            if (_playerData.CurrentCount > _playerData.MaxCount)
            {
                _playerData.SetMaxCount(_playerData.CurrentCount);
                PlayerMaxCountUpdated?.Invoke(_playerData.MaxCount);
            }

            _playerData.ResetCurrentCount();
            PlayerCountUpdated?.Invoke(_playerData.CurrentCount);
        }
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            CollisionDetected();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent(out ICollectable collectable))
            {
                CollectableDetected(collectable);
            }
        }

        private void OnCollisionEnter(Collision col)
        {
            CollisionDetected();
        }

        private void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.TryGetComponent(out ICollectable collectable))
            {
                CollectableDetected(collectable);
            }
        }

        
        private void CollisionDetected()
        {
            PlayerCollisionDetected?.Invoke();  
        }

        private void CollectableDetected(ICollectable collectable)
        {
            collectable.Collect();
            _playerData.UpdateCurrentCount(collectable.Value);
            PlayerCountUpdated?.Invoke(_playerData.CurrentCount);
        }
    }
}