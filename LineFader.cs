using UnityEngine;

public class LineFader : MonoBehaviour
{
    public GameObject player;
    private SpriteRenderer sr;
    public bool TrackX;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float a = 255;
        if (TrackX)
        {
            a = (Mathf.Max(Mathf.Abs(player.transform.position.x) - 20) / 5) * 180;
            print(a);
        }
        sr.color = new Color(255, 255, 255, a);
    }
}
