using Core;
using UI.Windows;
using UnityEngine;

namespace UI
{
    public class UIController : MonoBehaviour, IController
    {
        public StartWindowUI startWindow;
        public PlayWindowUI playWindow;
        public EndGameWindowUI endGameWindow;

        private IWindow[] _windows;

        public void Init()
        {
            IWindow[] allWindows = {startWindow, playWindow, endGameWindow};
            _windows = allWindows;
            
            HideAllWindows();
            startWindow.HideOrShow(true);
        }
        
        private void HideAllWindows()
        {
            foreach (var window in _windows)
            {
                window.HideOrShow(false);
            }
        }

        public void OnGameStarted()
        {
            HideAllWindows();
            playWindow.HideOrShow(true);
        }
        
        public void OnGameFinished()
        {
            HideAllWindows();
            endGameWindow.HideOrShow(true);
        }

        public void OnGameRestart()
        {
            HideAllWindows();
            startWindow.HideOrShow(true);
        }
    }
}