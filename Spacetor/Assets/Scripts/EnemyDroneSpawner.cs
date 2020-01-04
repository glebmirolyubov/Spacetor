using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDroneSpawner : MonoBehaviour
{
    public GameObject DronePrefab;

    private float xPoint;
    private float yPoint;

    void Start()
    {
        InvokeRepeating("SpawnEnemyDrone", 1f, 5f);
    }

    void SpawnEnemyDrone()
    {
        xPoint = Random.Range(0.1f, 0.9f);
        yPoint = Random.Range(0.6f, 0.9f);

        Vector3 spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(xPoint, yPoint, 10));
        Instantiate(DronePrefab, spawnPoint, Quaternion.identity);
    }

}
