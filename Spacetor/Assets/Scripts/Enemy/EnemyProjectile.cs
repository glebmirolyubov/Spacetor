using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    void FixedUpdate()
    {
        transform.position += transform.forward * Time.deltaTime * 10f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Turret")
        {
            PlayerManager.health -= 10;
            Camera.main.gameObject.GetComponent<CameraShake>().StartCoroutine("ShakeNormal");
            Destroy(gameObject);
        }
    }
}
