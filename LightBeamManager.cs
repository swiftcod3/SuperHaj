using UnityEngine;

public class LightBeamManager : MonoBehaviour
{
    public static LightBeamManager instance;

    [Header("Intensity Options")]

    public float minLightBeamIntensity;
    public float maxLightBeamIntensity;
    public float intensityOffsetMin;
    public float intensityOffsetMax;


    [Header("Size/Shape Options")]
    public float minLightBeamWidth;
    public float maxLightBeamWidth;
    public float minLightBeamHeight;
    public float maxLightBeamHeight;
    public float minLightBeamOffset;
    public float maxLightBeamOffset;
    public float LightBeamRotation;
    public float LightBeamRotationOffset;

    [Header("Misc options")]
    public float minLightBeamLoopTime;
    public float maxLightBeamLoopTime;

    void Awake()
    {
        instance = this;
    }
}
