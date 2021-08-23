using UnityEngine;

[ExecuteInEditMode] //For test
public class FluidController : MonoBehaviour
{
    [SerializeField] private Transform fluid;
    [SerializeField] private float maxHeightScale = 0.8f;

    [Range(0, 0.8f)]
    public float currentScale = 0; //For test, remove after script will be complete

    private void Update()
    {
        fluid.localScale = new Vector3(1f,currentScale, 1f); //Remove after script will be complete
    }

    public void ChangeWaterCount()
    {
        //����� ��������� ������� �������� ���������� ���������� � ����������� �� �������� �������� � ���� �������� 
        if(fluid.localScale.y < maxHeightScale)
        {

        }
    }
}
