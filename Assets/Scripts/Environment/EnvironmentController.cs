using Core;
using Environment.Effects;
using Environment.Levels;
using UnityEngine;

namespace Environment
{
    [RequireComponent(typeof(LevelsManager))]
    [RequireComponent(typeof(ParallaxManager))]

    public class EnvironmentController : MonoBehaviour, IController
    {
        private LevelsManager _levelsManager;
        private ParallaxManager _parallaxEffect;
        private SpeedController _speedController;
        
        public void Init()
        {
            _levelsManager = GetComponent<LevelsManager>();
            _levelsManager.Init();
            
            _parallaxEffect = GetComponent<ParallaxManager>();
            _parallaxEffect.Init();

            _speedController = gameObject.AddComponent<SpeedController>();
        }

        public void OnGameStarted()
        {
            _levelsManager.StartFirstLevel();
            _speedController.StartTrackTime();
        }

        public void OnGameFinished()
        {
            _levelsManager.StopMoving();
            _speedController.ResetSpeed();
        }

        public void OnGameRestart()
        {
            _levelsManager.Restart();
            _parallaxEffect.Refresh();
        }
    }
}