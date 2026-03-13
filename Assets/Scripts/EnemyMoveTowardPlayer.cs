using UnityEngine;

public class EnemyMoveTowardPlayer : MonoBehaviour
{
    public float speed = 1.5f;
    public float stopDistance = 1.0f;

    public Transform target;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // Works even if MainCamera tag is missing
        if (Camera.main != null) target = Camera.main.transform;
        if (target == null)
        {
            var xrCam = FindObjectOfType<Camera>();
            if (xrCam != null) target = xrCam.transform;
        }
    }

    void FixedUpdate()
    {
        if (!target) return;

        Vector3 to = target.position - transform.position;
        to.y = 0f;

        float dist = to.magnitude;
        if (dist <= stopDistance || dist < 0.001f) return;

        Vector3 dir = to / dist;
        Vector3 next = transform.position + dir * speed * Time.fixedDeltaTime;

        // If Rigidbody exists and is non-kinematic, move via physics
        if (rb != null && !rb.isKinematic)
            rb.MovePosition(next);
        else
            transform.position = next;

        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
    }
}