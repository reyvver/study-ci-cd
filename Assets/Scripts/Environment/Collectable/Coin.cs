using Core;
using Environment.Collectable;
using UnityEngine;

namespace Environment
{
    public class Coin : MonoBehaviour, ICollectable
    {
        [SerializeField] private ParticleSystem onCollect;
        [SerializeField] private CollectableValues.CollectableType collectableType = CollectableValues.CollectableType.Regular;
        [SerializeField] private LayerMask player;

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
            SoundController.Controller.PlaySound(Sound.SoundType.Collect);
            onCollect.Play();
            _spriteRenderer.enabled = false;
        }

        public void ResetCollectable()
        {
             if (onCollect.isPlaying)
                 onCollect.Stop();
             
             _spriteRenderer.enabled = true;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((player & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
            {
                Collect();
            }
        }
    }
}