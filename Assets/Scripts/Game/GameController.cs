using System;
using Environment;
using Player;
using UI;

namespace Game
{
    public class GameController
    {
        private GameController _instance;
        public GameController game => _instance;


        private event Action GameStarted;
        private event Action GameFinished;
        

        private PlayerController _playerController;
        private UIController _uiController;
        private EnvironmentController _environmentController;
        
        public GameController(PlayerController player, UIController ui, EnvironmentController env)
        {
            _playerController = player;
            _uiController = ui;
            _environmentController = env;
            
            InitAllControllers();
        }

        private void InitAllControllers()
        {
            _instance = this;

            _uiController.Init();
            _uiController.startWindow.ButtonStart += OnGameStart;

            GameStarted += _uiController.OnGameStarted;
            GameStarted += _playerController.OnGameStarted;
        }
        

        private void OnGameStart()
        {
            GameStarted?.Invoke();
        }
    }
}