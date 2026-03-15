using UnityEngine;

public class NetScript : MonoBehaviour
{
    public float netTimer;

    public Sprite sec3;
    public Sprite sec2;
    public Sprite sec1;
    public Sprite attack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = sec3;
    }

    // Update is called once per frame
    void Update()
    {
        netTimer += Time.deltaTime;
        if(netTimer > 0 )
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = sec3;
        } if (netTimer > 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sec2;
        }
        if (netTimer > 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sec1;
        }
        if (netTimer > 3)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = attack;

        }
        if (netTimer > 5)
        {
            Destroy(gameObject);
        }
    }
}
