using UnityEngine;

public class EnemyRocketDrone : MonoBehaviour
{
    public GameObject LeftRocket;
    public GameObject RightRocket;

    private float shootTimer;

    public bool allowShooting;

    void Start()
    {
        LeftRocket.GetComponent<EnemyRocketProjectile>().enabled = false;
        RightRocket.GetComponent<EnemyRocketProjectile>().enabled = false;

        shootTimer = Random.Range(1f, 3f);
        allowShooting = false;
    }

    void Update()
    {
        transform.LookAt(new Vector3(0f, 0f, 0f), Vector3.back);

        if (allowShooting)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer < 0)
            {
                ShootRocket();
            }
        }
    }

    void ShootRocket()
    {
        if (LeftRocket != null)
        {
            LeftRocket.GetComponent<EnemyRocketProjectile>().enabled = true;
        }
        else if (RightRocket != null)
        {
            RightRocket.GetComponent<EnemyRocketProjectile>().enabled = true;
        }
    }

    public void ActivateRocketTimer()
    {
        allowShooting = true;
    }

    public void DestroyShip()
    {
        Destroy(gameObject);
    }
}