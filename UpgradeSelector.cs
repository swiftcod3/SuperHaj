using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSelector : MonoBehaviour
{
    [Header("Upgrades")]
    [Header("Player Buffs:")]
    public float PlayerMoveSpeedMult = 1;
    public float PlayerFireRateMult = 1;
    public float PlayerDamage = 10;
    public int PlayerMaxHPBonus = 0;
    public float AttackSizeMult = 1;
    public float PlayerAccuracyRange = 0;

    [Header("Special Abilities")]
    public int bubbleCount = 0;
    public bool BubblesPop = false;
    public float PopSize = 3f;

    public bool HoldToFire = false;

    public GameObject smolhaj;

    [Header("Enemy Debuffs:")]
    public float enemyAttackSpeedMult = 1;


    [Header("Item Upgrade holders")]
    public GameObject upgrade1;
    public GameObject upgrade2;
    public GameObject upgrade3;

    [Header("Item Titles")]
    public GameObject title1;
    public GameObject title2;
    public GameObject title3;

    [Header("Item Descriptions")]
    public GameObject description1;
    public GameObject description2;
    public GameObject description3;

    [Header("Item Images")]
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;

    public Canvas upgradeUI;

    [Header("Sprites")]
    public Sprite Flag;
    public Sprite Meatballs;
    public Sprite Shelf;
    public Sprite Bag;
    public Sprite Bookcase;
    public Sprite Smolhaj;
    public Sprite Malm;
    public Sprite Barkass;

    int[] upgradeChoices = { 0, 0, 0 };

    readonly string[] upgradeNames = { "Swedish Flag", "Ikea Meatballs", "Kallax Shelf", "Frakta Bag", "Billy Bookcase", "Smolhaj", "Malm Bedside table", "Barkass Pendant Lamp" };
    readonly string[] upgradeDescriptions = {"2x Damage, -40% Firerate", "+30% Projectile Size", "+10% Movespeed", "Bullet Damage +5", "On kill, spawn 3 smaller bubbles. If this upgrade was taken in the past, +3 more bubbles spawned", "He be smol, and he shoot where you shoot :3", "1.5x Fire Rate, -30% Damage, and a lot more spread but you can hold to shoot instead of clicking", "+20% Fire Rate" };

    public bool isUpgrading = false;
    private float upgradeDuration;

    public static UpgradeSelector Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        upgradeUI.enabled = false;
    }

    private void Update()
    {
        upgradeDuration += Time.unscaledDeltaTime;
    }

    Sprite getSpriteFromID(int id)
    {
        return id switch
        {
            0 => Flag,
            1 => Meatballs,
            2 => Shelf,
            3 => Bag,
            4 => Bookcase,
            5 => Smolhaj,
            6 => Malm,
            7 => Barkass,
            _ => null,
        };

    }

    void giveUpgradeFromID(int id)
    {
        switch (id)
        {
            case 0:
                PlayerDamage *= 2;
                PlayerFireRateMult *= 0.6f;
                return;
            case 1:
                AttackSizeMult *= 1.3f;
                return;
            case 2:
                PlayerMoveSpeedMult += 0.1f;
                return;
            case 3:
                PlayerDamage += 5;
                return;
            case 4:
                BubblesPop = true;
                bubbleCount += 3;
                return;
            case 5:
                GameObject smol = Instantiate(smolhaj, transform.position, Quaternion.identity);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().smols.Add(smol.GetComponent<SmolhajController>());
                return;
            case 6:
                HoldToFire = true;
                PlayerFireRateMult *= 1.5f;
                PlayerDamage -= (PlayerDamage * 0.3f);
                PlayerAccuracyRange += 60;
                return;
            case 7:
                PlayerFireRateMult += 0.2f;
                return;
        }
    }

    public void GetUpgrade()
    {
        Time.timeScale = 0;
        isUpgrading = true;
        upgradeUI.enabled = true;
        upgradeChoices[0] = Random.Range(0, upgradeNames.Length);
        upgradeChoices[1] = Random.Range(0, upgradeNames.Length);
        upgradeChoices[2] = Random.Range(0, upgradeNames.Length);


        /*upgradeChoices[0] = 1;
        upgradeChoices[1] = 6;
        upgradeChoices[2] = 7;*/

        for (int upgradeID = 0; upgradeID < upgradeChoices.Length; upgradeID++)
        {
            while (upgradeChoices[upgradeID] == 6 && HoldToFire)
            {
                upgradeChoices[upgradeID] = Random.Range(0, upgradeNames.Length);
            }
        }

        title1.GetComponent<TMP_Text>().text = upgradeNames[upgradeChoices[0]];
        title2.GetComponent<TMP_Text>().text = upgradeNames[upgradeChoices[1]];
        title3.GetComponent<TMP_Text>().text = upgradeNames[upgradeChoices[2]];

        description1.GetComponent<TMP_Text>().text = upgradeDescriptions[upgradeChoices[0]];
        description2.GetComponent<TMP_Text>().text = upgradeDescriptions[upgradeChoices[1]];
        description3.GetComponent<TMP_Text>().text = upgradeDescriptions[upgradeChoices[2]];

        image1.GetComponent<Image>().sprite = getSpriteFromID(upgradeChoices[0]);
        image2.GetComponent<Image>().sprite = getSpriteFromID(upgradeChoices[1]);
        image3.GetComponent<Image>().sprite = getSpriteFromID(upgradeChoices[2]);

        upgradeDuration = 0;

    }

    public void CloseMenu()
    {
        upgradeUI.enabled = false;
        isUpgrading = false;
    }

    public void Upgrade1()
    {
        if (upgradeDuration < 0.8) return;
        giveUpgradeFromID(upgradeChoices[0]);
        StatTracker.instance.itemIDs.Add(upgradeChoices[0]);
        CloseMenu();
    }
    public void Upgrade2()
    {
        if (upgradeDuration < 0.8) return;
        giveUpgradeFromID(upgradeChoices[1]);
        StatTracker.instance.itemIDs.Add(upgradeChoices[1]);
        CloseMenu();
    }
    public void Upgrade3()
    {
        if (upgradeDuration < 0.8) return;
        giveUpgradeFromID(upgradeChoices[2]);
        StatTracker.instance.itemIDs.Add(upgradeChoices[2]);
        CloseMenu();
    }
}
