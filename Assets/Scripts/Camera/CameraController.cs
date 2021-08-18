using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private IMovable move;
    private ILook look;

    private void Start()
    {
        TryGetComponent(out move);
        TryGetComponent(out look);

        if (move == null)
            Debug.LogError(name + "object not have move script!");

        if (look == null)
            Debug.LogError(name + " object not have look script!");
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
        if (look == null) return;

        if(Input.GetMouseButton(1)) //Look only if right mouse button is pressed
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            look.Look(new Vector2(x, y));
        }           
    }
}
