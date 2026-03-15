using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Spawn Positions")]
    public GameObject[] positions;
    public float spawnDistance;

    [Header("Enemy Types")]
    public GameObject harpooner;
    public GameObject net;
    public GameObject submarine;
    public GameObject seaMineSpawner;

    [Header("Enemy Scaling")]
    public float EnemyHealthMult;

    int spawnAttempts = 1;
    int round = 0;

    public static EnemySpawner Instance;

    private void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 1)
        {
            round++;
            EnemyHealthMult = 1 + (round / 10.0f);
            spawnAttempts = (round * 3) -2;
            SpawnEnemies();
             if (round != 1) UpgradeSelector.Instance.GetUpgrade();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().RoundStart();
            StatTracker.instance.Round = round;
        }
    }

    public void SpawnEnemies()
    {
        while (spawnAttempts > 0)
        {
            spawnAttempts --;
            int spawnType = Random.Range(0, 4);
            if (spawnType == 0)
            {
                spawnHarpooners(Random.Range(2, 4));
            } else if (spawnType == 1)
            {
                spawnNetUser(Random.Range(1, 3));
            } else if (spawnType == 2)
            {
                if (round >= 3)
                {
                    spawnSubmarines(1);
                } else
                {
                    spawnHarpooners(Random.Range(2, 4));
                }
            } else
            {
                if (round >= 4)
                {
                    spawnSeaMineSub(1);
                }
                else
                {
                    spawnHarpooners(Random.Range(2, 4));
                }
            }
            
        }
    }

    void spawnSubmarines(int amount)
    {
        Vector3 offset = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized * spawnDistance;
        for (int i = 0; i < amount; i++)
        {
            Instantiate(submarine, positions[Random.Range(0, positions.Length)].transform.position + offset, Quaternion.identity);
        }
    }
    void spawnHarpooners(int amount)
    {
        Vector3 offset = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized * spawnDistance;
        for (int i = 0; i < amount; i++)
        {
            Instantiate(harpooner, positions[Random.Range(0, positions.Length)].transform.position + offset, Quaternion.identity);
        }
    }

    void spawnNetUser(int amount)
    {
        Vector3 offset = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized * spawnDistance;
        for (int i = 0; i < amount; i++)
        {
            Instantiate(net, positions[Random.Range(0, positions.Length)].transform.position + offset, Quaternion.identity);
        }
    }

    void spawnSeaMineSub(int amount)
    {
        Vector3 offset = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized * spawnDistance;
        for (int i = 0; i < amount; i++)
        {
            Instantiate(seaMineSpawner, positions[Random.Range(0, positions.Length)].transform.position + offset, Quaternion.identity);
        }
    }
}
