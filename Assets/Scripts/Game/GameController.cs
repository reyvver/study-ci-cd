using System;
using Core;
using Environment;
using Player;
using UI;

namespace Game
{
    public class GameController
    {
        private event Action GameStarted;
        private event Action GameFinished;
        private event Action GameRestarted;
        
        private readonly PlayerController _playerController;
        private readonly UIController _uiController;
        private readonly EnvironmentController _environmentController;
        
        public GameController(PlayerController player, UIController ui, EnvironmentController env)
        {
            _playerController = player;
            _uiController = ui;
            _environmentController = env;
            
            InitAllControllers();
            SubscribeToEvents();
        }

        ~GameController()
        {
            UnsubscribeFromEvents();
        }

        private void InitAllControllers()
        {
            _uiController.Init();
            _uiController.startWindow.ButtonStart += OnGameStart;
            _uiController.endGameWindow.ButtonRestart += OnGameRestart;
            
            _playerController.Init();
            _playerController.player.PlayerCollisionDetected += OnGameFinished;
            _playerController.player.PlayerCountUpdated += _uiController.playWindow.UpdateCount;
            _playerController.player.PlayerMaxCountUpdated += _uiController.startWindow.UpdateCount;

            _environmentController.Init();
        }

        private void SubscribeToEvents()
        {
            GameStarted += _uiController.OnGameStarted;
            GameStarted += _playerController.OnGameStarted;
            GameStarted += _environmentController.OnGameStarted;

            GameFinished += _uiController.OnGameFinished;
            GameFinished += _playerController.OnGameFinished;
            GameFinished += _environmentController.OnGameFinished;

            GameRestarted += _uiController.OnGameRestart;
            GameRestarted += _playerController.OnGameRestart;
            GameRestarted += _environmentController.OnGameRestart;
        }

        private void UnsubscribeFromEvents()
        {
            GameStarted -= _uiController.OnGameStarted;
            GameStarted -= _playerController.OnGameStarted;
            GameStarted -= _environmentController.OnGameStarted;

            GameFinished -= _uiController.OnGameFinished;
            GameFinished -= _playerController.OnGameFinished;
            GameFinished -= _environmentController.OnGameFinished;

            GameRestarted -= _uiController.OnGameRestart;
            GameRestarted -= _playerController.OnGameRestart;
            GameRestarted -= _environmentController.OnGameRestart;
        }

        private void OnGameStart()
        {
            GameStats.IsMoving = true;
            GameStarted?.Invoke();
        }

        private void OnGameRestart()
        {
            GameRestarted?.Invoke();
        }

        private void OnGameFinished()
        {
            GameStats.IsMoving = false;
            GameFinished?.Invoke();
        }
    }
}