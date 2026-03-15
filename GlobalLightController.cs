using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightController : MonoBehaviour
{
    GameObject player;
    Light2D Light;

    public float minIntensity;
    public float maxIntensity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Light = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.Clamp01((player.transform.position.y + 20) / (25 + 20));
        Light.intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
    }
}
