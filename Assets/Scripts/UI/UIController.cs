using Core;
using UnityEngine;

namespace UI
{
    public class UIController : MonoBehaviour, IController
    {
        public StartWindowUI startWindow;
        public PlayWindowUI playWindow;
        public EndGameWindowUI endGameWindow;

        private IWindow[] windows;

        public void Init()
        {
            IWindow[] allWindows = {startWindow, playWindow, endGameWindow};
            windows = allWindows;
            
            HideAllWindows();
        }
        
        private void HideAllWindows()
        {
            foreach (var window in windows)
            {
                window.HideOrShow(false);
            }
            
            startWindow.HideOrShow(true);
        }

        public void OnGameStarted()
        {
            startWindow.HideOrShow(false);
            playWindow.HideOrShow(true);
        }

        public void OnGameFinished()
        {
            endGameWindow.HideOrShow(true);
            playWindow.HideOrShow(false);
        }
    }
}