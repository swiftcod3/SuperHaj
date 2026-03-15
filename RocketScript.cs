using UnityEngine;

public class RocketScript: BulletScript
{
    [Header("Rocket Bullet Settings")]
    public float FuseDuration;
    public GameObject Explosion;
    public GameObject BubbleExplosion;
    private GameObject Player;

    [Header("Timersprites")]
    [SerializeField] Sprite timer1;
    [SerializeField] Sprite timer09;
    [SerializeField] Sprite timer08;
    [SerializeField] Sprite timer07;
    [SerializeField] Sprite timer06;
    [SerializeField] Sprite timer05;
    [SerializeField] Sprite timer04;
    [SerializeField] Sprite timer03;
    [SerializeField] Sprite timer02;
    [SerializeField] Sprite timer01;
    private SpriteRenderer sr;

    private void Awake()
    {
        spawnTime = Time.time;
        Player = GameObject.FindGameObjectWithTag("Player");
        Vector2 dir = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    private void Update()
    {
        if (Time.time - FuseDuration > spawnTime)
        {
            Explode();
        }
        /*if (Time.time - spawnTime > 0)
        {
            sr.sprite = timer1;
        }
        if (Time.time - spawnTime > 0.1)
        {
            sr.sprite = timer09;
        }
        if (Time.time - spawnTime > 0.2)
        {
            sr.sprite = timer08;
        }
        if (Time.time - spawnTime > 0.3)
        {
            sr.sprite = timer07;
        }
        if (Time.time - spawnTime > 0.4)
        {
            sr.sprite = timer06;
        }
        if (Time.time - spawnTime > 0.5)
        {
            sr.sprite = timer05;
        }
        if (Time.time - spawnTime > 0.6)
        {
            sr.sprite = timer04;
        }
        if (Time.time - spawnTime > 0.7)
        {
            sr.sprite = timer03;
        }
        if (Time.time - spawnTime > 0.8)
        {
            sr.sprite = timer02;
        }
        if (Time.time - spawnTime > 0.9)
        {
            sr.sprite = timer01;
        }*/

        direction += curve * Time.deltaTime;
        transform.position += speed * Time.deltaTime * direction.normalized;
    }

    public void Explode()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Instantiate(BubbleExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
