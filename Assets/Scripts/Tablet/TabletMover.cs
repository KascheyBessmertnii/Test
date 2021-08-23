using UnityEngine;

public class TabletMover : MonoBehaviour
{
    [SerializeField] protected GameObject tablet;
    [SerializeField] private Camera tabletCamera;
    [Header("Render textures")]
    [SerializeField] private RenderTexture horizontal;  
    [SerializeField] private RenderTexture vertical;
    [Header("Screen objects")]
    [SerializeField] private GameObject horizontalScreen;
    [SerializeField] private GameObject verticalScreen;

    private void Awake()
    {
        RotateTablet(new Vector3(0f, 0f, 0f), true, vertical);
    }

    private void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            RotateTablet(new Vector3(0f, 0f, 0f), true, vertical);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            RotateTablet(new Vector3(0f, 0f, -90f), false, horizontal);
        }
    }

    private void RotateTablet(Vector3 direction, bool vertical, RenderTexture texture)
    {
        tablet.transform.localRotation = Quaternion.Euler(direction);
        tabletCamera.targetTexture = texture;
        verticalScreen.SetActive(vertical);
        horizontalScreen.SetActive(!vertical);
    }
}
