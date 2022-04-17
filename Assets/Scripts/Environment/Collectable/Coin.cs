using Core;
using Environment.Collectable;
using UnityEngine;

namespace Environment
{
    public class Coin : MonoBehaviour, ICollectable
    {
        [SerializeField] private ParticleSystem onCollect;
        [SerializeField] private CollectableValues.CollectableType collectableType = CollectableValues.CollectableType.Regular;
        
        private SpriteRenderer _spriteRenderer;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public int Value
        {
            get => CollectableValues.GetTypeValue(collectableType);
            set
            {
            }
        }

        public void Collect()
        {
             onCollect.Play();
            _spriteRenderer.enabled = false;
        }

        public void ResetCollectable()
        {
             if (onCollect.isPlaying)
                 onCollect.Stop();
             
             _spriteRenderer.enabled = true;
        }
    }
}