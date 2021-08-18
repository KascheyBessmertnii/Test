using UnityEngine;

public class ValveController : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private Vector2 rotationLimits = new Vector2(0, 720);

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnMouseDrag()
    {
        RotateObject(transform);
    }

    private void RotateObject(Transform toRotate)
    {
        Vector3 dir = Input.mousePosition - mainCamera.WorldToScreenPoint(toRotate.position);

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion nextStep = Quaternion.AngleAxis(-angle, Vector3.up);
        toRotate.localRotation = nextStep;
    }
}
