using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Target;
    public float easing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= (transform.position - Target.transform.position) * easing;
        transform.position = new(transform.position.x, transform.position.y, -10);
    }
}
