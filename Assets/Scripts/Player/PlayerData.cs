using UnityEngine;

namespace Player
{
    public class PlayerData
    {
        public int MaxCount { get; private set; }
        public int CurrentCount { get; private set; }

        private static string MaxCountKey = "max_count";
        
        public PlayerData()
        {
            LoadStartData();
        }

        private void LoadStartData()
        {
            MaxCount = PlayerPrefs.GetInt(MaxCountKey, 0);
            CurrentCount = 0;
        }

        private void SaveCount(string key, int count)
        {
            PlayerPrefs.SetInt(key, count);
            PlayerPrefs.Save();
        }

        private void SaveAll()
        {
            SaveCount(MaxCountKey, MaxCount);
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
            SaveAll();
            CurrentCount = 0;
        }
    }
}