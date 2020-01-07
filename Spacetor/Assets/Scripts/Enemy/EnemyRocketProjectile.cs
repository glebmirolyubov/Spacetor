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
        explosionEffect.SetActive(true);
        GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Turret")
        {
            Health.health -= 20;
            missleEffect.SetActive(false);
            explosionEffect.SetActive(true);
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject, 2f);
        }
    }
}
