using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public static MouseLook Instance { get; private set; } = null;

    [Header("Mouse look")]
    [SerializeField] private float sensivity = 10f;
    [Header("Camera angle limits"), Tooltip("Set in this field minimal and maximum values to vertical angles")]
    [SerializeField] private Vector2 verticalLimits;

    private float yRot = 0f;
    private float xRot = 0f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("Mouse look already exist");
    }
    private void Start()
    {
        xRot = transform.localEulerAngles.y;
    }
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }          
    }
    public void Look(Transform target, Vector2 offset)
    {
        float y = offset.y * sensivity;
        float x = offset.x * sensivity;

        yRot -= y;
        yRot = Mathf.Clamp(yRot, verticalLimits.x, verticalLimits.y);

        xRot += x;

        target.localRotation = Quaternion.Euler(yRot, xRot, 0f);
    }
}
