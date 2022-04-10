using System.Collections.Generic;
using UnityEngine;

namespace Environment
{
    public class LevelsManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] levelsPrefabs;
        [SerializeField] private Transform obstacleHolder;
        
        private List<Level> _levels;
        private Level _currentLevel;

        public void Init()
        {
            _levels = new List<Level>();

            foreach (var prefab in levelsPrefabs)
            {
                var instance = Instantiate(prefab, obstacleHolder);
                var instanceLevel = instance.GetComponent<Level>();
                
                instanceLevel.Init();
                _levels.Add(instanceLevel);
            }
        }

        public void StartFirstLevel()
        {
            StartNewLevel();
        }

        private void StartNewLevel()
        {
            SetCurrentLevel();
            StartMoving();
        }

        private void SetCurrentLevel()
        {
            Level randomLevel;

            while (true)
            {
                int number = Random.Range(0, _levels.Count - 1);
                randomLevel = _levels[number];
                
                if (randomLevel != _currentLevel)
                    break;
            } 
            
            _currentLevel = randomLevel;
        }

        private void StartMoving()
        {
            if (_currentLevel == null) return;
            
            _currentLevel.StartMoving();
            _currentLevel.LevelFinished += OnLevelStopped;
        }

        public void StopMoving()
        {
            if (_currentLevel == null) return;

            _currentLevel.StopMoving();
            _currentLevel.LevelFinished -= OnLevelStopped;
        }

        public void Restart()
        {
            foreach (var level in _levels)
            {
                level.SetAtStartPosition();
            }

            _currentLevel = null;
        }

        private void OnLevelStopped()
        {
            _currentLevel.SetAtStartPosition();
            _currentLevel.LevelFinished -= OnLevelStopped;
            
            StartNewLevel();
        }
    }
}