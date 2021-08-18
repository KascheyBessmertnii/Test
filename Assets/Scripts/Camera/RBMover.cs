using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RBMover : MonoBehaviour, IMovable
{
    [SerializeField] private float speed = 200f;
    private Rigidbody rb;

    private void Start()
    {
        TryGetComponent(out rb);
    }

    public void Move(Vector3 direction)
    {
        Vector3 move = transform.right * direction.z + transform.forward * direction.x;

        rb.velocity = move * speed * Time.deltaTime;
    }

    public void Stop()
    {
        rb.velocity = Vector3.zero;
    }
}
