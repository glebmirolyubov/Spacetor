using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    private Touch touch;
    private Quaternion rotationZ;
    private float rotationSpeed = 0.2f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float XaxisRotation = Input.GetAxis("Mouse X") * 20;
            //float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
            transform.Rotate(Vector3.forward, XaxisRotation);
        }

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            float touchRatioY = touch.position.y / Screen.height;

            if (touch.phase == TouchPhase.Moved)
            {
                if (touchRatioY < 0.5f)
                {
                    rotationZ = Quaternion.Euler(0f, 0f, touch.deltaPosition.x * rotationSpeed);
                } else
                {
                    rotationZ = Quaternion.Euler(0f, 0f, -touch.deltaPosition.x * rotationSpeed);
                }

                transform.rotation = rotationZ * transform.rotation;
            }

        }
    }

    }