using UnityEngine;

public class TransformMover : MonoBehaviour, IMovable
{
    [SerializeField] private float speed = 2f;
    public void Move(Vector3 direction)
    {
        Vector3 mov = transform.right * (direction.z * speed) + transform.forward * (direction.x * speed);
        transform.position += mov * Time.deltaTime;
    }

    public void Stop() {}
}
