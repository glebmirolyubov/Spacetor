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
        InvokeRepeating("SpawnEnemyDrone", 1f, 3f);
        InvokeRepeating("SpawnEnemyRocketDrone", 15f, 5f);
    }

    void SpawnEnemyDrone()
    {
        xPoint = Random.Range(0.1f, 0.9f);
        yPoint = Random.Range(0.7f, 0.9f);

        Vector3 spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(xPoint, yPoint, 10));
        Instantiate(DronePrefab, spawnPoint, Quaternion.identity);
    }

    void SpawnEnemyRocketDrone()
    {
        xPoint = Random.Range(0.1f, 0.9f);
        yPoint = Random.Range(0.1f, 0.2f);

        Vector3 spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(xPoint, yPoint, 10));
        Instantiate(RocketDronePrefab, spawnPoint, Quaternion.identity);
    }

}
