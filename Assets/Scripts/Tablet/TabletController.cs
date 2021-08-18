using UnityEngine;

public class TabletController : MonoBehaviour
{
    [SerializeField] private GameObject tablet;

    private void Start()
    {
        if (tablet == null)
            Debug.LogWarning("Link to tablet not set in scripts!");
    }

    private void Update()
    {
        if (tablet != null && Input.GetKeyDown(KeyCode.Tab))
        {
            UpdateTabletView(true, CursorLockMode.None);
        }     
    }

    private void UpdateTabletView(bool visibleState, CursorLockMode lockMode)
    {
        if (tablet != null)
        {
            tablet.SetActive(visibleState);
            //Cursor.lockState = lockMode;
            //Cursor.visible = visibleState;
        }
    }
    /// <summary>
    /// Hide tablet using scene UI elements
    /// </summary>
    public void ButtonHideTablet()
    {
        UpdateTabletView(false, CursorLockMode.Locked);
    }
}
