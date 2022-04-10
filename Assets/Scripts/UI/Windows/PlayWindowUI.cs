using UnityEngine;

namespace UI.Windows
{
    public class PlayWindowUI: MonoBehaviour, IWindow
    {
        [SerializeField] private CanvasGroup canvas;
        
        public void HideOrShow(bool show)
        {
            canvas.alpha = show? 1 : 0;
            canvas.interactable = show;
            canvas.blocksRaycasts = show;
        }
    }
}