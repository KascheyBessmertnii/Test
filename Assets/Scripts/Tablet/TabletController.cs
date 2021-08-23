using UnityEngine;

public class TabletController : TabletMover
{
    private void Start()
    {
        if (tablet == null)
            Debug.LogWarning("Link to tablet not set in scripts!");
        else
            tablet.SetActive(true);
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
        }
    }
}
