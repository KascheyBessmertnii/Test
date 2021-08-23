using UnityEngine;

namespace Utility
{
    public class AngleAdditional
    {
        /// <summary>
        /// Return angle between mouse and target object position
        /// </summary>
        /// <param name="cam">Scene main camera</param>
        /// <param name="target">Target object</param>
        /// <returns></returns>
        public static float GetAngleToMouse(Camera cam, Transform target)
        {
            Vector3 dir = Input.mousePosition - cam.WorldToScreenPoint(target.position);

            return Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        }
    }
}

