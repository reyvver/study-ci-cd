using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class StartWindowUI : MonoBehaviour, IWindow
    {
        [SerializeField] private CanvasGroup canvas;
        [SerializeField] private Text textCount;

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
        
        public void UpdateCount(int count)
        {
            textCount.text = $"Max count: {count}";
        }
    }
}