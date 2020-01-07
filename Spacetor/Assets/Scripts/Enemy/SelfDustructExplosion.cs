using UnityEngine;

public class SelfDustructExplosion : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2f);
    }
}
