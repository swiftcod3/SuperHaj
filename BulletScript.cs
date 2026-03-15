using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Header("Generic Bullet Settings")]
    public Vector3 direction = Vector3.zero;
    public float speed = 1f;
    public Vector3 curve;
    protected float spawnTime;

    private void Awake()
    {
        spawnTime = Time.time;
    }
    private void Update()
    {
        if (Time.time - 20 > spawnTime)
        {
            Destroy(gameObject);
        }

        direction += curve * Time.deltaTime;
        transform.position += speed * Time.deltaTime * direction.normalized;
    }
}
