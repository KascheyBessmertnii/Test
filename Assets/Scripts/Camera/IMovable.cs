using UnityEngine;

public interface IMovable
{
    void Init(Transform targetObj);
    void Move(Vector3 direction);

    void Stop();
}
