using UnityEngine;

public class Projectile : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    void FixedUpdate()
    {
        transform.position += transform.up * Time.deltaTime * 10f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Drone")
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            Destroy(gameObject);
        }
    }
}
