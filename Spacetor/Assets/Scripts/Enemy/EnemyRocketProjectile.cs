using UnityEngine;

public class EnemyRocketProjectile : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject missleEffect;

    private bool death;

    void Start()
    {
        missleEffect.SetActive(true);
        death = false;
    }

    void FixedUpdate()
    {
        if (!death)
        {
            transform.position += transform.up * Time.deltaTime * 1.5f;
        }
    }

    public void DeathSequence()
    {
        death = true;
        missleEffect.SetActive(false);
        Instantiate(explosionEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Turret")
        {
            PlayerManager.health -= 20;
            Camera.main.gameObject.GetComponent<CameraShake>().StartCoroutine("ShakeRocket");
            death = true;
            missleEffect.SetActive(false);
            Instantiate(explosionEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}