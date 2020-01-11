using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI MenuScoreText;

    void Start()
    {
        score = 0;

        if (PlayerPrefs.HasKey("Score"))
        {
            MenuScoreText.text = "Best: " + PlayerPrefs.GetInt("Score");
        } else
        {
            MenuScoreText.text = "Best: 0";
        }
    }

    void Update()
    {
        ScoreText.text = score.ToString();
    }
}
