using UnityEngine;

public class Projectile : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void FixedUpdate()
    {
        transform.position += transform.up * Time.deltaTime * 5f;
    }
}
