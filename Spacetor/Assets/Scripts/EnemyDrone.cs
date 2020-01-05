using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrone : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public GameObject SpawnPoint;
    public GameObject ChargeParticle;

    private float shootTimer;

    void Start()
    {
        shootTimer = Random.Range(3f, 6f);
        //SpawnDroneOffScreen();
    }

    void Update()
    {
        transform.LookAt(new Vector3(0f, 0f, 0f), Vector3.back);

        shootTimer -= Time.deltaTime;
        if (shootTimer < 0)
        {
            ShootProjectile();
        } else
        {
            ChargeWeapon();
        }
    }

    void ChargeWeapon()
    {
        float newScale = Mathf.Lerp(0, 5, Time.deltaTime / (shootTimer*0.1f));
        ChargeParticle.transform.localScale = new Vector3(newScale, newScale, newScale);
    }

    void ShootProjectile()
    {
        Instantiate(ProjectilePrefab, SpawnPoint.transform.position, transform.rotation);
        shootTimer = Random.Range(3f, 6f);
        ChargeParticle.transform.localScale = Vector3.zero;
    }

    void SpawnDroneOffScreen()
    {
        transform.GetChild(0).localPosition = new Vector3(transform.GetChild(0).localPosition.x, transform.GetChild(0).localPosition.y, -30f);
    }
}
