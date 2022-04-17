using UnityEngine;

namespace Environment.Effects
{
    public class ParallaxManager : MonoBehaviour
    {
        [SerializeField] private ParallaxEffect[] parallaxBackground;
        
        public void Init()
        {
            foreach (var parallaxObj in parallaxBackground)
            {
                var duplicate = Instantiate(parallaxObj, parallaxObj.ParallaxTransform.parent);
                duplicate.ParallaxTransform.position = parallaxObj.ParallaxTransform.position;
                
                duplicate.Init();
                parallaxObj.Init();
                
                duplicate.SetAtRightPos();
            }
        }

        public void Refresh()
        {
            foreach (var parallaxObj in parallaxBackground)
            {
                parallaxObj.ResetAfterMovement();
            }
        }
    }
}