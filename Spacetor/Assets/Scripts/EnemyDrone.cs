using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrone : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public GameObject SpawnPoint;
    public GameObject ChargeParticle;

    private float shootTimer;

    public bool allowCharge;

    void Start()
    {
        shootTimer = Random.Range(3f, 6f);
        ChargeParticle.SetActive(false);
        allowCharge = false;
    }

    void Update()
    {
        transform.LookAt(new Vector3(0f, 0f, 0f), Vector3.back);

        if (allowCharge)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer < 0)
            {
                ShootProjectile();
            }
            else
            {
                ChargeWeapon();
            }
        }
    }

    void ChargeWeapon()
    {
        float newScale = Mathf.Lerp(0, 5, Time.deltaTime / (shootTimer * 0.05f));
        ChargeParticle.transform.localScale = new Vector3(newScale, newScale, newScale);
    }

    void ShootProjectile()
    {
        Instantiate(ProjectilePrefab, SpawnPoint.transform.position, transform.rotation);
        shootTimer = Random.Range(3f, 6f);
        ChargeParticle.transform.localScale = Vector3.zero;
    }

    public void ActivateChargeParticle()
    {
        ChargeParticle.SetActive(true);
        allowCharge = true;
    }

    public void DestroyShip()
    {
        Destroy(gameObject);
    }
}
