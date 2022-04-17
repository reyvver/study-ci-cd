using Core;
using UnityEngine;

namespace Environment.Effects
{
    [RequireComponent(typeof(SpriteScaler))]
    public class ParallaxEffect : MonoBehaviour, IMoving
    {
        [SerializeField] private float parallaxFactor;
        
        public Transform ParallaxTransform => transform;
        private Vector3 _objPosition;

        public void Init()
        {
            _objPosition = ParallaxTransform.position;
            gameObject.GetComponent<SpriteScaler>().Scale();
        }
        public void ResetAfterMovement()
        {
            ParallaxTransform.position = _objPosition;
        }

        public void SetAtRightPos()
        {
            ParallaxTransform.position = new Vector3(ParallaxTransform.lossyScale.x, _objPosition.y, _objPosition.z);
            _objPosition = ParallaxTransform.position;
        }

        private void Update()
        {
            if (!GameStats.IsMoving)
                return;

            var difference = ParallaxTransform.position.x + ParallaxTransform.lossyScale.x;
            var moveValue = Vector3.left * Time.deltaTime * (GameStats.Speed + parallaxFactor);
            
            if (difference <= 0)
            {
                ParallaxTransform.position = new Vector3(ParallaxTransform.lossyScale.x - Mathf.Abs(difference), _objPosition.y, _objPosition.z);
            }
            
            ParallaxTransform.Translate(moveValue);
        }
    }
}