using System;
using UnityEngine;

namespace UI
{
    public class StartWindowUI : MonoBehaviour, IWindow
    {
        [SerializeField] private CanvasGroup canvas;
        public event Action ButtonStart;
        
        public void HideOrShow(bool show)
        {
            canvas.alpha = show? 1 : 0;
            canvas.interactable = show;
            canvas.blocksRaycasts = show;
        }

        public void OnButtonStartClick()
        {
            ButtonStart?.Invoke();
        }
        
    }
}