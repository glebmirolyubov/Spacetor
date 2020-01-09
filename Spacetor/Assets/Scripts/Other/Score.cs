using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score;

    public TextMeshProUGUI ScoreText;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        ScoreText.text = score.ToString();
    }
}
