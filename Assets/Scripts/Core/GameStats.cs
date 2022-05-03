using UnityEngine;

namespace Core
{
    public static class GameStats
    {
        public static float Speed = StartSpeed;
        public static int CountEachTime = 1;
        public static bool IsMoving;
        public static bool IsGameStopped;
        public static Camera Cam;
        
        public const float StartSpeed = 8;
        public const float Acceleration = 0.45f;
    }
}