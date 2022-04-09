using Environment;
using Player;
using UI;
using UnityEngine;

namespace Game
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private PlayerController PlayerController;
        [SerializeField] private UIController _uiController;
        [SerializeField] private EnvironmentController _environmentController;

        private void Awake()
        {
            GameController gameController = new GameController(PlayerController, _uiController, _environmentController);
        }
    }
}