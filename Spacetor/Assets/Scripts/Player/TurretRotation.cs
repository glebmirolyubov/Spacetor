using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class TurretRotation : MonoBehaviour
{
    public Slider ControlsSlider;

    private Touch touch;
    private Quaternion rotationZ;
    private float rotationSpeed = 0.2f;

    void FixedUpdate()
    {

        transform.rotation = Quaternion.Slerp(Quaternion.Euler(0f, 0f, 90f), Quaternion.Euler(0f, 0f, -90f), ControlsSlider.value);
        //transform.rotation = Quaternion.Euler(-90f, transform.rotation.eulerAngles.y, 0f);

        /*
        float XaxisRotation = CrossPlatformInputManager.GetAxis("Horizontal") * 20;
        transform.Rotate(Vector3.forward, XaxisRotation);


        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            float touchRatioY = touch.position.y / Screen.height;

            if (touch.phase == TouchPhase.Moved)
            {
                if (touchRatioY < 0.2f)
                {
                    rotationZ = Quaternion.Euler(0f, 0f, -touch.deltaPosition.x * rotationSpeed);
                } else
                {
                    rotationZ = Quaternion.Euler(0f, 0f, -touch.deltaPosition.x * rotationSpeed);
                }

                transform.rotation = rotationZ * transform.rotation;
                transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            }

        }
        */
    }

}