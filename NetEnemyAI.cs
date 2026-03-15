using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class NetEnemyAI : EnemyAI
{
    public GameObject net;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sr = GetComponent<SpriteRenderer>();
        health *= EnemySpawner.Instance.EnemyHealthMult;
    }

    public override void PerformAttack()
    {
        GameObject bullet = GameObject.Instantiate(net, player.transform.position, Quaternion.identity);
        fireRateTimer = 0;
    }

    public override void IncrementStats()
    {
        StatTracker.instance.NetterKills += 1;
    }
}
