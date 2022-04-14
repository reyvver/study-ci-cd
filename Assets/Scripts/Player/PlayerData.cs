using UnityEngine;

namespace Player
{
    public class PlayerData
    {
        public int MaxCount { get; private set; }
        public int CurrentCount { get; private set; }

        private const string MaxCountKey = "max_count";
        private const string CurrentCountKey = "current_count";
        
        public PlayerData()
        {
            LoadStartData();
        }

        ~PlayerData()
        {
            SaveAll();
        }
        
        private void LoadStartData()
        {
            MaxCount = PlayerPrefs.GetInt(MaxCountKey, 0);
            CurrentCount = PlayerPrefs.GetInt(CurrentCountKey, 0);
        }

        private void SaveCount(string key, int count)
        {
            PlayerPrefs.SetInt(key, count);
            PlayerPrefs.Save();
        }

        private void SaveAll()
        {
            SaveCount(MaxCountKey, MaxCount);
            SaveCount(CurrentCountKey, CurrentCount);
        }

        public void UpdateCurrentCount(int value)
        {
            CurrentCount += value;
        }
        
        public void SetMaxCount(int value)
        {
            MaxCount = value;
        }

        public void ResetCurrentCount()
        {
            CurrentCount = 0;
        }
    }
}