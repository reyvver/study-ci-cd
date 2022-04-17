using UnityEngine;

namespace Environment.Effects
{
    public class SpriteScaler: MonoBehaviour
    {
        private Transform SpriteTransform => transform;
        
        public void Scale()
        {
            float width = ScreenSize.GetScreenToWorldWidth;
            Vector3 currentLocalScale = SpriteTransform.localScale;
            
            SpriteTransform.localScale = new Vector3(Mathf.RoundToInt(width), currentLocalScale.y, currentLocalScale.z);
        }
    }
}