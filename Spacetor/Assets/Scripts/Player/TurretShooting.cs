using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public GameObject SpawnPoint;
    public Transform Turret;

    float time = 0.1f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            //StartCoroutine(Shoot());

            if (time >= 0)
            {
                time -= Time.deltaTime;
                return;
            }
            else
            {
                SpawnLeftProjectile();
                time = 0.1f;
            }

        }
    }

    public void SpawnLeftProjectile()
    {
        Instantiate(ProjectilePrefab, SpawnPoint.transform.position, Turret.transform.rotation);
    }

    IEnumerator Shoot ()
    {
        while (Input.touchCount > 0)
        {
            SpawnLeftProjectile();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
