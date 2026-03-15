using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class SubmarineEnemyAI : EnemyAI
{
    public GameObject torpedo;
    public GameObject summon;
    private int count;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sr = GetComponent<SpriteRenderer>();
        health *= EnemySpawner.Instance.EnemyHealthMult;
    }

    public override void PerformAttack()
    {
        GameObject bullet = GameObject.Instantiate(torpedo, transform.position, transform.rotation);
        bullet.GetComponent<BulletScript>().direction = -(transform.position - player.transform.position).normalized;
        bullet.GetComponent<BulletScript>().speed = bulletSpeed;
        fireRateTimer = 0;
        count++;
        if (count > 2)
        {
            count = 0;
            Instantiate(summon, transform.position, transform.rotation);
        }
    }

    public override void IncrementStats()
    {
        StatTracker.instance.SubmarineKills += 1;
    }
}
