using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Sprite frame0;
    [SerializeField] private Sprite frame1;
    [SerializeField] private Sprite frame2;
    [SerializeField] private Sprite frame3;
    [SerializeField] private Sprite frame4;
    [SerializeField] private Sprite frame5;
    [SerializeField] private Sprite frame6;
    [SerializeField] private Sprite frame7;
    public float frameTime;
    private float timer;
    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > frameTime * 8)
        {
            Destroy(gameObject);
        }
        if (timer > frameTime * 7)
        {
            sr.sprite = frame7;
            return;
        }
        if (timer > frameTime * 6)
        {
            sr.sprite = frame6;
            return;
        }
        if (timer > frameTime * 5)
        {
            sr.sprite = frame5;
            return;
        }
        if (timer > frameTime * 4)
        {
            sr.sprite = frame4;
            return;
        }
        if (timer > frameTime * 3)
        {
            sr.sprite = frame3;
            return;
        }
        if (timer > frameTime * 2)
        {
            sr.sprite = frame2;
            return;
        }
        if (timer > frameTime * 1)
        {
            sr.sprite = frame1;
            return;
        }
        if (timer > frameTime * 0)
        {
            sr.sprite = frame0;
            return;
        }
    }
}
