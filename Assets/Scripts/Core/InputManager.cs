using UnityEngine;

namespace Core
{
    public static class InputManager
    {
        public static bool TouchBegin()
        {
            return Input.GetMouseButtonDown(0);
        }
        public static bool TouchHold()
        {
            return Input.GetMouseButton(0);
        }

        public static bool TouchRelease()
        {
            return Input.GetMouseButtonUp(0);
        }
    }
}