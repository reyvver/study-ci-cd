using System.Collections.Generic;
using UnityEngine;

namespace Environment.Effects
{
    public class ParallaxManager : MonoBehaviour
    {
        [SerializeField] private ParallaxEffect[] parallaxBackground;
        private List<ParallaxEffect> _effects;
        
        public void Init()
        {
            _effects = new List<ParallaxEffect>();
            
            foreach (var parallaxObj in parallaxBackground)
            {
                parallaxObj.Init();

                var duplicate = Instantiate(parallaxObj, parallaxObj.ParallaxTransform.parent);
                duplicate.ParallaxTransform.position = parallaxObj.ParallaxTransform.position;
                
                duplicate.Init();
                duplicate.SetAtRightPos();
                
                _effects.Add(parallaxObj);
                _effects.Add(duplicate);
            }
        }

        public void Refresh()
        {
            foreach (var parallaxObj in _effects)
            {
                parallaxObj.ResetAfterMovement();
            }
        }
    }
}