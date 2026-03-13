using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 1;
    public int points = 1;

    public void Hit(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            if (ScoreManager.I) ScoreManager.I.Add(points);
            Destroy(gameObject);
        }
    }
}