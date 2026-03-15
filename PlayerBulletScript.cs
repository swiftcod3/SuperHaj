using UnityEngine;

public class PlayerBulletScript : BulletScript
{
    [Header("Player Bullet Settings")]
    public bool CanPop;
    public GameObject pop;
    public float popSize = 1;
    private float GlobalPopSize;
    private bool hasPopped;

    private void Update()
    {
        if (Time.time - 20 > spawnTime)
        {
            Destroy(gameObject);
        }

        direction += curve * Time.deltaTime;
        transform.position += speed * Time.deltaTime * direction.normalized;
    }


    private void Awake()
    {
        spawnTime = Time.time;
        transform.localScale *= UpgradeSelector.Instance.AttackSizeMult;
    }

    public void Pop()
    {
        if (hasPopped) return;
        hasPopped = true;
        if (UpgradeSelector.Instance.BubblesPop && CanPop)
        {
            GlobalPopSize = UpgradeSelector.Instance.PopSize;
            for (int i = 0; i < UpgradeSelector.Instance.bubbleCount; i++)
            {
                SpawnBubble();
            }
        }
    }

    private void SpawnBubble()
    {
        GameObject p = Instantiate(pop, transform.position, Quaternion.identity);
        p.transform.localScale = new(popSize * GlobalPopSize, popSize * GlobalPopSize, 1);
        p.GetComponent<PlayerBulletScript>().direction = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-3.0f, 1.0f)).normalized;
    }
}
