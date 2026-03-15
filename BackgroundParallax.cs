using Unity.VisualScripting;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform target;
    public float parallaxMult;

    private GameObject targetGO;
    void Start()
    {
        if (target == null)
        {
            target = Camera.main.gameObject.transform;
            targetGO = Camera.main.gameObject;
        } else
        {
            targetGO = target.GameObject();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
            transform.position = new(target.position.x * parallaxMult, target.position.y * parallaxMult, 10);
        else
        {
            GameObject targetGO = GameObject.FindGameObjectWithTag("Player");
            if (targetGO != null)
            {
                target = targetGO.transform;
            }
        }
    }
}