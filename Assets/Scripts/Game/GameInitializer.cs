using Core;
using Environment;
using Player;
using UI;
using UnityEngine;

namespace Game
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private UIController uiController;
        [SerializeField] private EnvironmentController environmentController;
        [Space] 
        [SerializeField] private Camera mainCamera;

        private void Awake()
        {
            GameStats.cam = mainCamera;
            GameController gameController = new GameController(playerController, uiController, environmentController);
        }
    }
}