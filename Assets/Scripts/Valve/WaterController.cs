using UnityEngine;

public class WaterController
{
    //maximum parameters for water particle system
    private static float maxStartSpeed = 3.6f;
    private static float maxStartSize = 1.8f;

    //current parameters for water particle system
    public static float speedStep { get; private set; } = 0;
    public static float sizeStep { get; private set; } = 0;

    /// <summary>
    /// Initialize default step values for speed water and size water. 
    /// </summary>
    /// <param name="maxOpenAngle">Maximum angle for valve</param>
    public static void Initialize(ParticleSystem waterParticleSystem, float maxOpenAngle)
    {
        //Set steps size use max open angle valve
        speedStep = maxStartSpeed / maxOpenAngle;
        sizeStep = maxStartSize / maxOpenAngle;

        SetWaterParametersByValveAngle(waterParticleSystem, 0); //In initialize particle system set they in 0
    }

    /// <summary>
    /// Update water particle system parameters by current valve angle
    /// </summary>
    /// <param name="valveAngle">Current valve angle</param>
    public static void SetWaterParametersByValveAngle(ParticleSystem waterParticleSystem, float valveAngle)
    {
        if (waterParticleSystem == null) return;
        var ps = waterParticleSystem.main;
        ps.startSpeed = speedStep * valveAngle;
        ps.startSize = sizeStep * valveAngle;
    }
}
