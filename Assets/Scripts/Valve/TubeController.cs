using UnityEngine;

public class TubeController : MonoBehaviour
{
    [SerializeField] private ParticleSystem waterPSystem;
    [SerializeField] private float maxStartSpeed = 3.6f;
    [SerializeField] private float maxStartSize = 1.8f;

    private float speedStep = 0;
    private float sizeStep = 0;

    private void Start()
    {
        ChangeWaterPower(0);
    }

    public void Initialize(float maxOpenAngle)
    {
        //Set steps size use max open angle valve
        speedStep = maxStartSpeed / maxOpenAngle;
        sizeStep = maxStartSize / maxOpenAngle;
    }

    public void ChangeWaterPower(float valveAngle)
    {
        if (waterPSystem == null) return;
        var ps = waterPSystem.main;
        ps.startSpeed = speedStep * valveAngle;
        ps.startSize = sizeStep * valveAngle;
    }
}
