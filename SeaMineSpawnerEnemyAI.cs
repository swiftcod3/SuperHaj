using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class SeaMineSpawnerEnemyAi : EnemyAI
{
    public GameObject summon;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sr = GetComponent<SpriteRenderer>();
        health *= EnemySpawner.Instance.EnemyHealthMult;
    }

    public override void PerformAttack()
    {
        Instantiate(summon, transform.position, Quaternion.identity);
        fireRateTimer = 0;
    }

    public override void IncrementStats()
    {
        StatTracker.instance.SeaMineSpawnerKills += 1;
    }
}
