using Core;
using UnityEngine;

namespace Player
{
    public  class PlayerController : MonoBehaviour, IController
    {
        public Player player;
        
        public void Init()
        { 
            player.Init();   
        }

        public void OnGameStarted()
        {
            player.SetPlayerReady();
        }

        public void OnGameFinished()
        {
            player.StopPlayer();
        }

        public void OnGameRestart()
        {
            player.Restart();
        }
    }
}