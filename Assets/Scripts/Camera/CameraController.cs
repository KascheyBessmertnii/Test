using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform moveObject = default;

    private IMovable move;
    private MouseLook mLook;

    private void Start()
    {
        TryGetComponent(out move);

        if (move == null)
            Debug.LogError(name + "object not have move script!");
        else
            move.Init(moveObject);

        mLook = MouseLook.Instance;
    }

    private void Update()
    {
        OnMove();
        OnLook();
    }

    private void OnMove()
    {
        if (move == null) return;

        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");

        if (x != 0 || z != 0)
        {
            move.Move(new Vector3(x, 0, z));
        }
        else
            move.Stop();
    }

    private void OnLook()
    {
        if (Input.GetMouseButton(1)) //Look only if right mouse button is pressed
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            mLook.Look(moveObject, new Vector2(x, y));
        }
    }
}
