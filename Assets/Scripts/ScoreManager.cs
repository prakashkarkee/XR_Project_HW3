using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager I;
    public int score;
    public TMP_Text scoreText;

    void Awake() => I = this;

    public void Add(int pts)
    {
        score += pts;
        if (scoreText) scoreText.text = $"Score: {score}";
    }
}