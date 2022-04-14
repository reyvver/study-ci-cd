using Core;
using UnityEngine;

namespace Environment
{
    public class Coin : MonoBehaviour, ICollectable
    {
        [SerializeField] private ParticleSystem onCollect;
        private SpriteRenderer _spriteRenderer;
        private const int CoinValue = 50;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            Value = CoinValue;
        }

        public int Value
        {
            get; set;
        }

        public void Collect()
        {
            // onCollect.Play();
            _spriteRenderer.enabled = false;
        }

        public void ResetCollectable()
        {
            // if (onCollect.isPlaying)
            //     onCollect.Stop();
            
            _spriteRenderer.enabled = true;
        }
    }
}