using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 6f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision c)
    {
        var enemy = c.collider.GetComponentInParent<Enemy>();
        if (enemy != null)
        {
            enemy.Hit(1);
            Destroy(gameObject); // destroy only when hitting enemy
        }
        // else: do NOT destroy (so it won't vanish when touching gun/floor)
    }
}