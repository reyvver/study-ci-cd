using Core;
using UnityEngine;

namespace Environment.Effects
{
    public static class ScreenSize
    { 
        public static float GetScreenToWorldWidth
        {
            get
            {
                Vector2 topRightCorner = new Vector2(1, 1);
                Vector2 edgeVector = GameStats.Cam.ViewportToWorldPoint(topRightCorner);
                var width = edgeVector.x * 2;
                return width;
            }
        }
    }
}