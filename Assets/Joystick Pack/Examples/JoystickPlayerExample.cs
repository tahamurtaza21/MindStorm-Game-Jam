using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public DynamicJoystick dynamicJoystick;

    public void Update()
    {
        float xRot = speed * dynamicJoystick.Horizontal;
        float yRot = speed * dynamicJoystick.Vertical;


        transform.Rotate(Mathf.Clamp(-yRot,-90f,90f), Mathf.Clamp(xRot,-90f,90f), 0.0f);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);

    }
}
