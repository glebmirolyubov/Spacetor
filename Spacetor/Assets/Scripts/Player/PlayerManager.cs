using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static int health;

    public GameObject HealthHolder;
    public GameObject PlayerExplosion;
    public GameObject Player;
    public GameObject MusicSource;
    public GameObject StartPanel;
    public GameObject ScoreObject;
    public GameObject TutorialPanel;
    public StoresSetup storesSetup;
    public EnemyDroneSpawner droneSpawner;
    public AdSetup adSetup;

    private bool death;

    void Awake()
    {
        Time.timeScale = 1;
        Camera.main.orthographicSize = 1.5f;
        Camera.main.gameObject.GetComponent<EnemyDroneSpawner>().enabled = false;
    }

    void Start()
    {
        health = 100;
        death = false;
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
        Player.SetActive(false);
        Instantiate(PlayerExplosion, Player.transform.position, Quaternion.identity);
        health = 0;
        SetBestScore();
        adSetup.ShowCenterBanner();
        adSetup.ShowVideoAd();
        GetComponent<Animator>().SetTrigger("Death");
    }

    public void StartGame()
    {
        Camera.main.GetComponent<Animator>().SetTrigger("StartGame");
        MusicSource.GetComponent<Animator>().SetTrigger("StartGame");
        GetComponent<Animator>().SetTrigger("StartGame");
    }

    public void FinishDeath()
    {
        Time.timeScale = 0;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void FinishStart()
    {
        StartPanel.SetActive(false);
        HealthHolder.SetActive(true);
        ScoreObject.SetActive(true);

        if (PlayerPrefs.HasKey("Tutorial"))
        {
            droneSpawner.enabled = true;
        } else
        {
            GetComponent<Animator>().SetTrigger("Tutorial");
            droneSpawner.enabled = false;
        }
    }

    void SetBestScore()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            if (PlayerPrefs.GetInt("Score") < Score.score)
            {
                PlayerPrefs.SetInt("Score", Score.score);
                storesSetup.PostScoreOnLeaderBoard(Score.score);
            }

        } else
        {
            PlayerPrefs.SetInt("Score", Score.score);
            storesSetup.PostScoreOnLeaderBoard(Score.score);
        }
    }

    public void CompleteTutorial()
    {
        PlayerPrefs.SetInt("Tutorial", 1);
        GetComponent<Animator>().SetTrigger("EndTutorial");
        TutorialPanel.SetActive(false);
        droneSpawner.enabled = true;
    }
}