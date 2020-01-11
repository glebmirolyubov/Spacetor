using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDroneSpawner : MonoBehaviour
{
    public GameObject DronePrefab;
    public GameObject RocketDronePrefab;

    private float xPoint;
    private float yPoint;

    void Start()
    {
        InvokeRepeating("SpawnEnemyDroneFirstWave", 2f, 3f);
        InvokeRepeating("SpawnEnemyRocketDroneFirstWave", 30f, 15f);
        InvokeRepeating("SpawnEnemyDroneSecondWave", 40f, 10f);
        InvokeRepeating("SpawnEnemyRocketDroneSecondWave", 60f, 20f);
    }

    void SpawnEnemyDroneFirstWave()
    {
        xPoint = Random.Range(0.1f, 0.9f);
        yPoint = Random.Range(0.7f, 0.9f);

        Vector3 spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(xPoint, yPoint, 10));
        Instantiate(DronePrefab, spawnPoint, Quaternion.identity);
    }

    void SpawnEnemyRocketDroneFirstWave()
    {
        xPoint = Random.Range(0.1f, 0.9f);
        yPoint = Random.Range(0.8f, 0.95f);

        Vector3 spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(xPoint, yPoint, 10));
        Instantiate(RocketDronePrefab, spawnPoint, Quaternion.identity);
    }

    void SpawnEnemyDroneSecondWave()
    {
        xPoint = Random.Range(0.1f, 0.9f);
        yPoint = Random.Range(0.1f, 0.35f);

        Vector3 spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(xPoint, yPoint, 10));
        Instantiate(DronePrefab, spawnPoint, Quaternion.identity);

    }

    void SpawnEnemyRocketDroneSecondWave()
    {
        xPoint = Random.Range(0.1f, 0.9f);
        yPoint = Random.Range(0.1f, 0.2f);

        Vector3 spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(xPoint, yPoint, 10));
        Instantiate(RocketDronePrefab, spawnPoint, Quaternion.identity);
    }

}
