using UnityEngine;

public class TabletMover : MonoBehaviour
{
    [SerializeField] private Camera tabletCamera;
    [Header("Render textures")]
    [SerializeField] private RenderTexture horizontal;  
    [SerializeField] private RenderTexture vertical;
    [Header("Screen objects")]
    [SerializeField] private GameObject horizontalScreen;
    [SerializeField] private GameObject verticalScreen;

    private void Start()
    {
        RotateTablet(new Vector3(0f, 0f, 0f), true, vertical);
    }

    private void Update()
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
        transform.localRotation = Quaternion.Euler(direction);
        tabletCamera.targetTexture = texture;
        verticalScreen.SetActive(vertical);
        horizontalScreen.SetActive(!vertical);
    }
}
