using UnityEngine;
using Utility;

public class ValveController : MonoBehaviour
{
    [SerializeField] private ParticleSystem waterParticleSystem = default;
    [Header("Valve settings")]
    [SerializeField] private Vector2 rotationLimits = new Vector2(0, 720);

    private Camera mainCamera;

    private Quaternion previousRotate;
    private float totalDeegres = 0;

    private void Start()
    {
        mainCamera = Camera.main;
        previousRotate = transform.rotation;

        WaterController.Initialize(waterParticleSystem,rotationLimits.y);
    }

    private void OnMouseDrag()
    {
        RotateObject(transform);
    }

    private void OnMouseDown()
    {
        previousRotate = SetNewRotate();
    }
    private void RotateObject(Transform toRotate)
    {
        toRotate.localRotation = SetNewRotate(); //Rotate object use mouse moving

        SetTotalAngles(toRotate.localRotation);

        if (!CheckLimitsAngles(toRotate)) return;

        previousRotate = toRotate.localRotation;
        WaterController.SetWaterParametersByValveAngle(waterParticleSystem,totalDeegres);
    }

    private Quaternion SetNewRotate()
    {
        float angle = AngleAdditional.GetAngleToMouse(mainCamera, transform);

        return Quaternion.AngleAxis(-angle, Vector3.up);
    }

    /// <summary>
    /// Set open valve angle
    /// </summary>
    /// <param name="q">Qauternion between old and new rotation</param>
    private void SetTotalAngles(Quaternion q)
    {
        float rotateAngle = Quaternion.Angle(previousRotate, transform.rotation);

        int direction = 0;
        if (q.y > previousRotate.y)
            direction = -1;
        else if (q.y < previousRotate.y)
            direction = 1;

        totalDeegres += rotateAngle * direction;
    }

    /// <summary>
    /// Check current valva angle, if they not between angle limits set valve rotation to previous angle
    /// </summary>
    /// <param name="toRotate">Object for rotate back if its need</param>
    /// <returns></returns>
    private bool CheckLimitsAngles(Transform toRotate)
    {
        if (totalDeegres > rotationLimits.y)
        {
            totalDeegres = rotationLimits.y;
            toRotate.rotation = previousRotate;
            return false;
        }
        else if (totalDeegres < rotationLimits.x)
        {
            totalDeegres = rotationLimits.x;
            toRotate.rotation = previousRotate;
            return false;
        }
        return true;
    }
}
