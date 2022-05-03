using System.Collections;
using Core;
using UnityEngine;

namespace Environment
{
    public class SpeedController : MonoBehaviour
    {
        private const float ChangeDuration = 1.5f;
        private const float ChangePeriod = 15f; 

        private bool _isActive;
        private float _timeTrack;

        private void Update()
        {
            if (!_isActive) return;

            if (_timeTrack >= ChangePeriod)
            {
                IncreaseSpeed();
                _timeTrack = 0;
            }

            _timeTrack += Time.deltaTime;
        }

        public void StartTrackTime()
        {
            _isActive = true;
        }
        
        public void ResetSpeed()
        {
            _timeTrack = 0;
            _isActive = false;
            GameStats.Speed = GameStats.StartSpeed;
        }
        
        private void IncreaseSpeed()
        {
            StartCoroutine(IncreaseSpeedInTime());
        }
        
        private IEnumerator IncreaseSpeedInTime()
        {
            float time = 0;
            float startValue = GameStats.Speed;
            float endValue = GameStats.Speed + GameStats.Acceleration;


            while (time <= ChangeDuration)
            {
                GameStats.Speed = Mathf.Lerp(startValue, endValue, time / ChangeDuration);
                time += Time.deltaTime;
                yield return null;
            }
        }
        
    }
}