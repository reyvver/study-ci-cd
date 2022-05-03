using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class Sound
    {
        public enum SoundType
        {
            None,
            Music,
            Click,
            Collect,
            Lose
        }

        public SoundType soundType;
        public AudioClip audio;
        [HideInInspector] public AudioSource source;
        [Range(0,1)] public float volume;
        [Range(0,3)] public float pitch;
    }
    public class SoundManager : MonoBehaviour
    {
        [Space] [SerializeField] private List<Sound> gameSounds;
        
        public void Init()
        {
            foreach (var sound in gameSounds)
            {
                SoundController.Controller.AddSound(sound, gameObject);
            }
        }
    }

    public class SoundController
    {
        private static SoundController _instance;

        public static SoundController Controller
        {
            get { return _instance ??= new SoundController(); }
        }

        private readonly List<Sound> _gameSounds = new List<Sound>();


        public void AddSound(Sound sound, GameObject parent)
        {
            AudioSource source = parent.AddComponent<AudioSource>();

            source.clip = sound.audio;
            source.volume = sound.volume;
            source.pitch = sound.pitch;
            source.playOnAwake = false;
            source.spatialBlend = 0;
            source.mute = false;
            source.loop = sound.soundType == Sound.SoundType.Music;
            
            sound.source = source;
            Controller._gameSounds.Add(sound);
        }
        

        public void PlaySound(Sound.SoundType soundType)
        {
            var sound = Controller._gameSounds.Find(s => s.soundType == soundType);
            
            if(sound == null) return;
            if (sound.source.clip == null) return;
            
            if(sound.source.isPlaying)
                sound.source.Stop();
            
            sound.source.Play();
        }
    }
}