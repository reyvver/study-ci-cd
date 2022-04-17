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
        
        public void Init()
        {
            _levelsManager = GetComponent<LevelsManager>();
            _levelsManager.Init();
            
            _parallaxEffect = GetComponent<ParallaxManager>();
            _parallaxEffect.Init();
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
            _parallaxEffect.Refresh();
        }
    }
}