using UnityEngine;

public class SeaMineRadius : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponentInParent<SeaMineEnemyAI>().Explode(collision);
        }
    }
}
