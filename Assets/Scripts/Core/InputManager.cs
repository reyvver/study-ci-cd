using UnityEngine;

namespace Core
{
    public static class InputManager
    {
        public static bool TouchHold()
        {
            return Input.GetMouseButton(0);
        }
    }
}