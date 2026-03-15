using UnityEngine;

public class SmolhajController : MonoBehaviour
{
    public GameObject Target;
    public float easing;
    public Vector3 offset;
    public GameObject bulletPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        transform.position = Target.transform.position;
        easing = Random.Range(0.81f, 1.35f);
        offset = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized * 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - (Target.transform.position + offset)).x > 0 && offset != Vector3.zero){
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if ((transform.position - (Target.transform.position + offset)).x < 0 && offset != Vector3.zero)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        transform.position -= (transform.position - (Target.transform.position + offset)) * easing * Time.deltaTime;
        transform.position = new(transform.position.x, transform.position.y, -5);
    }

    public void SmolhajShoot(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        direction = new Vector2(direction.x * Random.Range(0.5f, 1.4f), direction.y * Random.Range(0.5f, 1.4f));

        bullet.GetComponent<BulletScript>().speed = 6f;

        bullet.GetComponent<BulletScript>().direction = direction;
        bullet.GetComponent<BulletScript>().direction.z = 0;
    }
}
