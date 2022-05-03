using UnityEngine;

namespace Core
{
    public static class InputManager
    {
        public static bool TouchBegin()
        {
#if UNITY_EDITOR
            return Input.GetMouseButtonDown(0);
#else
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return touch.phase == TouchPhase.Began;
        }

        return false;
#endif
        }
        public static bool TouchHold()
        {
#if UNITY_EDITOR
            return Input.GetMouseButton(0);
#else
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary;
        }

        return false;
#endif
        }

        public static bool TouchRelease()
        {
#if UNITY_EDITOR
            return Input.GetMouseButtonUp(0);
#else
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return touch.phase == TouchPhase.Ended;
        }

        return false;
#endif
        }
    }
}