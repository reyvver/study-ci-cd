using Core;
using UnityEngine;

namespace Environment
{
    [RequireComponent(typeof(LevelsManager))]
    public class EnvironmentController : MonoBehaviour, IController
    {
        private LevelsManager _levelsManager;
        
        public void Init()
        {
            _levelsManager = GetComponent<LevelsManager>();
            _levelsManager.Init();
        }

        public void OnGameStarted()
        {
            _levelsManager.StartFirstLevel();
        }

        public void OnGameFinished()
        {
            _levelsManager.StopMoving();
        }

        public void OnGameRestart()
        {
            _levelsManager.Restart();
        }
    }
}