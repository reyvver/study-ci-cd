using System;
using Core;
using UnityEngine;

namespace Environment
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private float startPosX;
        [SerializeField] private float endPosX;
        [Space]
        [SerializeField] private Transform collectableHolder;

        public event Action LevelFinished;

        private Transform LevelTransform => gameObject.transform;
        private Vector3 _startPos;
        private Vector3 _endPos;
        private bool _isMoving;
        private static float speed = 5;
        
        private void Update()
        {
            if (!_isMoving) return;

            LevelTransform.position += new Vector3(-1 * Time.deltaTime * speed, 0, 0);

            if (Vector3.Distance(LevelTransform.position, _endPos) <= 1f) 
                OnDestinationReached();
        }

        public void Init()
        {
            _startPos = new Vector3(startPosX, 0, 0);
            _endPos = new Vector3(endPosX, 0, 0);
            
            _isMoving = false;
            SetAtStartPosition();
        }
        
        public void StartMoving()
        {
            _isMoving = true;
        }

        public void StopMoving()
        {
            _isMoving = false;
        }
        
        public void SetAtStartPosition()
        {
            LevelTransform.position = _startPos;
            ResetCollectables();
        }

        private void OnDestinationReached()
        {
            StopMoving();
            LevelFinished?.Invoke();
        }

        private void ResetCollectables()
        {
            if (collectableHolder == null) return;
            
            for (var i = 0; i < collectableHolder.childCount; i++)
            {
                if (collectableHolder.GetChild(i).TryGetComponent(out ICollectable collectable))
                {
                    collectable.ResetCollectable();
                }
            }
        }
        
    }
}