using UnityEngine;

public class ValveController : MonoBehaviour
{
    [SerializeField] private Vector2 rotationLimits = new Vector2(0, 720);

    private Camera mainCamera;

    private int direction = 0;

    private Quaternion previousRotate;
    [SerializeField]private float totalDeegres = 0; //Make serialize for debug

    private void Start()
    {
        mainCamera = Camera.main;
        previousRotate = transform.rotation;
    }

    private void OnMouseDrag()
    {
        RotateObject(transform);
    }

    private void RotateObject(Transform toRotate)
    {
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            Vector3 dir = Input.mousePosition - mainCamera.WorldToScreenPoint(toRotate.position);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion nextStep = Quaternion.AngleAxis(-angle, Vector3.up);
            toRotate.localRotation = nextStep;
            float a = Quaternion.Angle(previousRotate, transform.rotation);
            totalDeegres += a * CheckDirection();
            if (!CheckLimitsAngles(toRotate)) return;
            previousRotate = toRotate.localRotation;            
        }
    }

    private int CheckDirection()
    {
        if (previousRotate.eulerAngles.y > transform.rotation.eulerAngles.y)
            return 1;
        else if (previousRotate.eulerAngles.y < transform.rotation.eulerAngles.y)
            return -1;
        return 0;
    }

    private bool CheckLimitsAngles(Transform toRotate)
    {
        if (totalDeegres > rotationLimits.y)
        {
            totalDeegres = rotationLimits.y;
            toRotate.rotation = previousRotate;
            return false;
        }
        else if (totalDeegres < 0)
        {
            totalDeegres = 0;
            toRotate.rotation = previousRotate;
            return false;
        }
        return true;
    }
}
