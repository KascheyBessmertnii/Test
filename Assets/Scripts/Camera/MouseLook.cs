using UnityEngine;

public class MouseLook : MonoBehaviour, ILook
{
    [SerializeField] private float sensivity = 10f;
    [Header("Limits"), Tooltip("Set in this field minimal and maximum values to vertical angles")]
    [SerializeField] private Vector2 verticalLimits;

    private float yRot = 0f;
    private float xRot = 0f;

    private void Start()
    {
        xRot = transform.localEulerAngles.y;
    }

    public void Look(Vector2 offset)
    {
        float y = offset.y * sensivity;
        float x = offset.x * sensivity;

        yRot -= y;
        yRot = Mathf.Clamp(yRot, verticalLimits.x, verticalLimits.y);

        xRot += x;

        transform.localRotation = Quaternion.Euler(yRot, xRot, 0f);
    }
}
