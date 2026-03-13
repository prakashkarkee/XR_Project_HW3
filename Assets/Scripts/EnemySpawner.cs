using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float interval = 2f;

    float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Spawn();
            timer = interval;
        }
    }

    void Spawn()
    {
        if (!enemyPrefab || spawnPoints == null || spawnPoints.Length == 0) return;
        var p = spawnPoints[Random.Range(0, spawnPoints.Length)];
        // Instantiate(enemyPrefab, p.position, p.rotation);
        var e = Instantiate(enemyPrefab, p.position, p.rotation);

        var mover = e.GetComponent<EnemyMoveTowardPlayer>();
        if (mover != null)
            mover.target = Camera.main.transform;
    }
}