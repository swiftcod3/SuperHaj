using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightbeamController : MonoBehaviour
{
    private Light2D Light;
    [SerializeField] private float minIntensity;
    [SerializeField] private float maxIntensity;
    [SerializeField] private float loopDuration;
    [SerializeField] private float loopTime;
    [SerializeField] private float offset;
    [SerializeField] private float rotation;
    [SerializeField] private float minOffset;
    [SerializeField] private float maxOffset;
    Vector3 originalPosition;
    private float time;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LightBeamManager instance = LightBeamManager.instance;
        Light = GetComponent<Light2D>();
        minIntensity = Random.Range(instance.minLightBeamIntensity, instance.maxLightBeamIntensity);
        maxIntensity = minIntensity + Random.Range(instance.intensityOffsetMin, instance.intensityOffsetMax);
        loopTime = Random.Range(instance.minLightBeamLoopTime, instance.maxLightBeamLoopTime);
        offset = loopTime * Random.Range(0.0f, 1.0f);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, instance.LightBeamRotationOffset) + instance.LightBeamRotation);
        transform.localScale = new Vector3(Random.Range(instance.minLightBeamWidth, instance.maxLightBeamWidth), transform.localScale.y, transform.localScale.z);
        originalPosition = transform.position;
        minOffset = originalPosition.x - Random.Range(instance.intensityOffsetMin, instance.intensityOffsetMax);
        maxOffset = originalPosition.x + Random.Range(instance.intensityOffsetMin, instance.intensityOffsetMax);
    }

    // Update is called once per frame
    void Update()
    {
        time = Mathf.PingPong(Time.time + offset, loopTime) / loopTime;

        Light.intensity = Mathf.Lerp(minIntensity, maxIntensity, time);
        transform.position = new Vector3( Mathf.Lerp(minOffset, maxOffset, time), originalPosition.y, originalPosition.z) ;
    }
}
