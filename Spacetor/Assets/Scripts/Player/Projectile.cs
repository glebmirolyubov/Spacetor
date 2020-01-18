using UnityEngine;

public class Projectile : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    void FixedUpdate()
    {
        transform.position += transform.up * Time.deltaTime * 20f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Drone")
        {
            if (collision.gameObject.transform.parent.gameObject.GetComponent<EnemyDrone>().allowCharge == true)
            {
                collision.gameObject.transform.parent.gameObject.GetComponent<EnemyDrone>().droneHealth -= 1;

                if (collision.gameObject.transform.parent.gameObject.GetComponent<EnemyDrone>().droneHealth == 1)
                {
                    collision.gameObject.transform.parent.gameObject.GetComponent<EnemyDrone>().FireParticle.SetActive(true);
                }
                else
                {
                    collision.gameObject.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("Death");
                    Score.score += 2;
                }
            }
            Destroy(gameObject);
        }

        if (collision.tag == "RocketDrone")
        {
            if (collision.gameObject.transform.parent.gameObject.GetComponent<EnemyRocketDrone>().allowShooting == true)
            {
                collision.gameObject.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("Death");
                Score.score += 3;
            }
            Destroy(gameObject);
        }

        if (collision.tag == "Rocket")
        {
            collision.gameObject.GetComponent<EnemyRocketProjectile>().DeathSequence();
            Score.score++;
            Destroy(gameObject);
        }
    }
}
