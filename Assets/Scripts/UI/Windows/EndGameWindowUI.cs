using System;
using UnityEngine;

namespace UI.Windows
{
    public class EndGameWindowUI : MonoBehaviour, IWindow
    {
        [SerializeField] private CanvasGroup canvas;
        public event Action ButtonRestart;

        public void HideOrShow(bool show)
        {
            canvas.alpha = show? 1 : 0;
            canvas.interactable = show;
            canvas.blocksRaycasts = show;
        }

        public void OnRestartButtonClick()
        {
            ButtonRestart?.Invoke();
        }
    }
}