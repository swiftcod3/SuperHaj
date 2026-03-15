using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class SeaMineEnemyAI : EnemyAI
{
    public GameObject exploson;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sr = GetComponent<SpriteRenderer>();
        health *= EnemySpawner.Instance.EnemyHealthMult;
    }

    public override void PerformAttack()
    {
        fireRateTimer = 0;
    }

    public override void IncrementStats()
    {
        StatTracker.instance.SeaMineKills += 1;
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Explode(collision);
        base.OnTriggerEnter2D(collision);
    }
    public void Explode(Collider2D collision)
    {
        if ((collision.CompareTag("PlayerBullet") && health - UpgradeSelector.Instance.PlayerDamage <= 0) || collision.CompareTag("Player"))
        {
            Instantiate(exploson, transform.position, Quaternion.identity);
        }
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
