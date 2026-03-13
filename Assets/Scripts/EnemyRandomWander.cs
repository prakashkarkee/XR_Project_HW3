using UnityEngine;

public class EnemyRandomWander : MonoBehaviour
{
    public float speed = 1.2f;
    public float roamRadius = 3.0f;
    public float changeTargetEvery = 2.0f;
    public float stopDistance = 0.2f;

    Vector3 origin;
    Vector3 targetPos;
    float timer;

    void Start()
    {
        origin = transform.position;
        PickNewTarget();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeTargetEvery)
        {
            timer = 0f;
            PickNewTarget();
        }

        Vector3 to = targetPos - transform.position;
        to.y = 0f;

        float dist = to.magnitude;
        if (dist <= stopDistance)
        {
            PickNewTarget();
            return;
        }

        Vector3 dir = to / dist;
        transform.position += dir * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
    }

    void PickNewTarget()
    {
        Vector2 r = Random.insideUnitCircle * roamRadius;
        targetPos = new Vector3(origin.x + r.x, transform.position.y, origin.z + r.y);
    }
}