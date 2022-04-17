using Core;
using UnityEngine;

namespace Environment.Effects
{
    [RequireComponent(typeof(SpriteScaler))]
    public class ParallaxEffect : MonoBehaviour, IMoving
    {
        [SerializeField] private float parallaxFactor;

        public Transform ParallaxTransform => transform;
        public Vector3 objPosition;
        
        private float _sizeX;

        public void Init()
        {
            objPosition = ParallaxTransform.position;
            gameObject.GetComponent<SpriteScaler>().Scale();
            _sizeX = GetComponent<SpriteRenderer>().bounds.size.x;
        }
        
        public void ResetAfterMovement()
        {
            ParallaxTransform.position = objPosition;
        }

        public void SetAtRightPos()
        {
            ParallaxTransform.position = new Vector3(_sizeX, objPosition.y, objPosition.z);
            objPosition = ParallaxTransform.position;
        }

        private void Update()
        {
            if (GameStats.IsGameStopped) return;
            
            var difference = ParallaxTransform.position.x + _sizeX;
            var moveValue = Vector3.left * Time.deltaTime * (GameStats.Speed + parallaxFactor);
            
            if (difference <= 0)
            {
                ParallaxTransform.position = new Vector3(_sizeX - Mathf.Abs(difference), objPosition.y, objPosition.z);
            }
            
            ParallaxTransform.Translate(moveValue);
        }
    }
}