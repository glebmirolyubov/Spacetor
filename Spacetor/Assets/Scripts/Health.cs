using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public static int health;

    public GameObject deathCanvas;
    public Text healthText;

    private bool death;

    void Awake()
    {
        Time.timeScale = 1;
    }

    void Start()
    {
        health = 100;
        death = false;
        deathCanvas.SetActive(false);
    }

    void Update()
    {
        healthText.text = health.ToString();

        if (health <= 0 && !death)
        {
            death = true;
            Death();
        }
    }

    void Death()
    {
        deathCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
