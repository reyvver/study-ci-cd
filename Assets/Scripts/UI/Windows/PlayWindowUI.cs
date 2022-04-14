using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class PlayWindowUI: MonoBehaviour, IWindow
    {
        [SerializeField] private CanvasGroup canvas;
        [SerializeField] private Text textCount;
        
        public void HideOrShow(bool show)
        {
            canvas.alpha = show? 1 : 0;
            canvas.interactable = show;
            canvas.blocksRaycasts = show;
        }

        public void UpdateCount(int count)
        {
            textCount.text = $"Count: {count}";
        }
    }
}