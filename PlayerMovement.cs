using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed = 1f;
    public float timeScaleStart = 1;
    public float timescaletimer = 0;
    public float timescalegoal;
    public float timescalegoaltime = 0;
    public float maxSpeed;
    public int maxHealth = 1;
    int health;

    public float attackSpeed = 0;
    private float attackTimer = 0;

    public float bottom;
    public float sides;
    public float top;

    public GameObject bulletPrefab;
    Vector3 velocity;
    public List<SmolhajController> smols;

    private UpgradeSelector upgrader;
    public bool IsDead;

    float lerp (float a, float b, float t)
    {
        return (a + (b - a)) * t;
    }

    void Start()
    {
        Application.targetFrameRate = 60;
        health = maxHealth + UpgradeSelector.Instance.PlayerMaxHPBonus;
        upgrader = UpgradeSelector.Instance;
    }

    void movement()
    {
        bool w = Input.GetKey(KeyCode.W);
        bool a = Input.GetKey(KeyCode.A);
        bool s = Input.GetKey(KeyCode.S);
        bool d = Input.GetKey(KeyCode.D);

        moveValue = new Vector2();

        if (w & s)
        {
            moveValue.y = 0;
        }
        if (s & !w)
        {
            moveValue.y = -1;
        }
        if (!s & w)
        {
            moveValue.y = 1;
        }
        if (d & a)
        {
            moveValue.x = 0;
        }
        if (a & !d)
        {
            moveValue.x = -1;
        }
        if (!a & d)
        {
            moveValue.x = 1;
        }


        Vector3 direction = new Vector3(moveValue.x, moveValue.y, 0).normalized;

        if (IsDead || upgrader.isUpgrading)
        {
            direction = Vector3.zero;
        }

        velocity += UpgradeSelector.Instance.PlayerMoveSpeedMult * speed * direction;
        velocity *= 0.85f;
        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
        gameObject.transform.position += velocity * Time.deltaTime;


        if (!upgrader.isUpgrading && !IsDead)
        {
            if (moveValue.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (moveValue.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        float target = moveValue == Vector2.zero ? 0.1f : 1f;

        if (target != timescalegoal)
        {
            timescalegoal = target;
            timescaletimer = 0f;
            timeScaleStart = Time.timeScale;
        }

        timescaletimer += Time.unscaledDeltaTime;

        float t = timescaletimer / timescalegoaltime;
        Time.timeScale = Mathf.Clamp(
            Mathf.Lerp(timeScaleStart, timescalegoal, t),
            0.1f,
            1f
        );

        if (upgrader.isUpgrading)
        {
            Time.timeScale = 0f;
        }
        if (IsDead)
        {
            Time.timeScale = 0.1f;
        }
    }

    public void RoundStart()
    {
        health = maxHealth;
    }
    void Update()
    {
        movement();
        attackTimer += Time.deltaTime * UpgradeSelector.Instance.PlayerFireRateMult;
        if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space) || ((Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Space)) && UpgradeSelector.Instance.HoldToFire)) && attackTimer > attackSpeed) {
            if (IsDead || upgrader.isUpgrading)
            {
                return;
            }
                attackTimer = 0;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            direction.Normalize();

            float randomRotation = UnityEngine.Random.Range(-0.5f * UpgradeSelector.Instance.PlayerAccuracyRange, 0.5f * UpgradeSelector.Instance.PlayerAccuracyRange);
            direction = Quaternion.AngleAxis(randomRotation, Vector3.forward) * direction;

            bullet.GetComponent<BulletScript>().speed = 6f;

            bullet.GetComponent<BulletScript>().direction = direction;
            bullet.GetComponent<BulletScript>().direction.z = 0;

            

            foreach (SmolhajController haj in smols)
            {
                haj.SmolhajShoot(direction);
            }
        }
        
        if(transform.position.y < bottom)
        {
            transform.position = new(transform.position.x, bottom);
        }
        if (transform.position.y > top)
        {
            transform.position = new(transform.position.x, top);
        }
        if (transform.position.x > sides)
        {
            transform.position = new(sides, transform.position.y);
        }
        if (transform.position.x < -sides)
        {
            transform.position = new(-sides, transform.position.y);
        }
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            health -= 1;
            if(health <= 0 && !IsDead)
            {
                upgrader.isUpgrading = true;
                IsDead = true;
                foreach (var GO in GameObject.FindGameObjectsWithTag("FadeInOnDeath"))
                {
                    StartCoroutine(GO.GetComponent<FadeInRaw>().Action(1.5f));
                }
            }
            RocketScript rocket;
            if ( collision.gameObject.TryGetComponent<RocketScript>(out rocket))
            {
                rocket.Explode();
            }
            GetComponent<SpriteRenderer>().flipY = true;
            if (collision.name == "Explosion(Clone)" || collision.name == "Net(Clone)") return;
            Destroy(collision.gameObject);
        }
    }

    
}
