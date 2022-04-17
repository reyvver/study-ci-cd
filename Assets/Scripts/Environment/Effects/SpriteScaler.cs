using UnityEngine;

namespace Environment.Effects
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteScaler: MonoBehaviour
    {
        private Transform SpriteTransform => transform;
        
        public void Scale()
        {
            float width = ScreenSize.GetScreenToWorldWidth;
            Vector3 currentLocalScale = SpriteTransform.localScale;

            var spriteBounds = GetComponent<SpriteRenderer>().bounds.size.x;
            
            if (spriteBounds < width)
                SpriteTransform.localScale = new Vector3(Mathf.RoundToInt(width), currentLocalScale.y, currentLocalScale.z);
        }
    }
}