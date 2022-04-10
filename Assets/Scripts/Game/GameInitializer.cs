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

        private void Awake()
        {
            GameController gameController = new GameController(playerController, uiController, environmentController);
        }
    }
}