using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public GameObject harpoon;
    public float targetDistance = 10f;
    public float speed;
    public float bulletSpeed;
    public float fireRate;
    public float fireRateTimer;
    public float health;
    public float speedRandomness;
    public float targetDistanceRandomness;
    [SerializeField] protected float rotationOffset = 0f;
    [SerializeField] protected bool ShouldRotate = true;
    [SerializeField] protected bool ShouldFlip = true;
    protected SpriteRenderer sr;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sr = GetComponent<SpriteRenderer>();
        health *= EnemySpawner.Instance.EnemyHealthMult;
        speed += Random.Range(-speedRandomness, speedRandomness);
        targetDistance += Random.Range(-targetDistanceRandomness, targetDistanceRandomness);
    }

    // Update is called once per frame
    void Update()
    {
        fireRateTimer += Time.deltaTime;

        Vector2 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        
        if (ShouldRotate)
        {
            if (dir.x < 0)
            {
                if (ShouldFlip) { sr.flipX = false; }
                if (ShouldRotate) { transform.rotation = Quaternion.Euler(0f, 0f, angle - rotationOffset - 75); }
            }
            else
            {
                if (ShouldFlip) { sr.flipX = true; }
                if (ShouldRotate) { transform.rotation = Quaternion.Euler(0f, 0f, angle + rotationOffset - 90); }
            }
        } else
        {
            if (dir.x < 0)
            {
                if (ShouldFlip) { sr.flipX = true; }
            }
            else
            {
                if (ShouldFlip) { sr.flipX = false; }
            }
        }

        if ((transform.position - player.transform.position).magnitude > targetDistance)
        {
            transform.position -= speed * Time.deltaTime * (transform.position - player.transform.position).normalized;
        }
        else if (fireRateTimer > fireRate * UpgradeSelector.Instance.enemyAttackSpeedMult)
        {
            PerformAttack();
        }

    }
    public virtual void PerformAttack()
    {
        GameObject bullet = GameObject.Instantiate(harpoon, transform.position, transform.rotation);
        bullet.GetComponent<BulletScript>().direction = -(transform.position - player.transform.position).normalized;
        bullet.GetComponent<BulletScript>().speed = bulletSpeed;
        fireRateTimer = 0;
    }
    public virtual void IncrementStats()
    {
        StatTracker.instance.HarpoonerKills += 1;

    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            health -= UpgradeSelector.Instance.PlayerDamage;

            if (health < 0)
            {
                collision.GetComponent<PlayerBulletScript>().Pop();
            }
            Destroy(collision.gameObject);
            if (health < 0)
            {
                if(!player.GetComponent<PlayerMovement>().IsDead)
                {
                    IncrementStats();

                }
                Destroy(gameObject);

            }
        }
    }
}
