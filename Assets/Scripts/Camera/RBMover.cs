using UnityEngine;

public class RBMover : MonoBehaviour, IMovable
{
    [SerializeField] private float speed = 200f;
    private Rigidbody rb;

    public void Init(Transform targetObj)
    {
        targetObj.TryGetComponent(out rb);
        if (rb == null)
            Debug.LogError("Moving script not initialized, object " + targetObj.name + " not have Rigidboy component!");
    }

    public void Move(Vector3 direction)
    {
        if (rb == null) return;

        Vector3 move = rb.transform.right * direction.z + rb.transform.forward * direction.x;

        rb.velocity = move * speed * Time.deltaTime;
    }

    public void Stop()
    {
        if (rb == null) return;
        rb.velocity = Vector3.zero;
    }
}
