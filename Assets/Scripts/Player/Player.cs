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
        private bool _distanceCheck;
        private float _time = 0;
        
        public event Action PlayerCollisionDetected;
        public event Action<int> PlayerCountUpdated;
        public event Action<int> PlayerMaxCountUpdated;

        private void Update()
        {
            if (!GameStats.IsMoving || !_distanceCheck) return;

            _time += Time.deltaTime;
            
            if (_time >= 1) // each second
            {
                _time = 0;
                UpdatePlayerCount(GameStats.CountEachTime);
            }
        }
        
        public void Init()
        {
            _playerMovement = gameObject.GetComponent<PlayerMovement>();
            _playerMovement.Init();
            _position = transform.position;
            
            _playerData = new PlayerData();
        }

        public void SetPlayerReady()
        {
            _time = 0;
            _distanceCheck = true;
            _playerMovement.ApproveMotion();
        }

        public void StopPlayer()
        {
            _distanceCheck = false;
            _playerMovement.StopMotion();
        }

        public void FetchPlayerData()
        {
            UpdateMaxCount();
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
                UpdateMaxCount();
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
            UpdatePlayerCount(collectable.Value);
        }

        private void UpdatePlayerCount(int value)
        {
            _playerData.UpdateCurrentCount(value);
            PlayerCountUpdated?.Invoke(_playerData.CurrentCount);
        }

        private void UpdateMaxCount()
        {
            PlayerMaxCountUpdated?.Invoke(_playerData.MaxCount);
        }
    }
}