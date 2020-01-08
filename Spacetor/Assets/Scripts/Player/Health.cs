using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public static int health;

    public GameObject deathCanvas;
    public GameObject HealthHolder;

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
        HealthHolder.transform.localScale = new Vector3(health * 0.01f, 1f, 1f);

        if (health <= 0 && !death)
        {
            death = true;
            Death();
        }
    }

    void Death()
    {
        health = 0;
        deathCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
