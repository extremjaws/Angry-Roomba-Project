using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public float SensitivityX;
    public float SensitivityY;
    public Transform playerBody;
    float xRotation;
    float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera>().enabled = true;
        GetComponent<AudioListener>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 joyvalue = Gamepad.current.rightStick.ReadValue();
        float mouseX = joyvalue.x * SensitivityX * Time.deltaTime;
        float mouseY = joyvalue.y * SensitivityY * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        yRotation = Mathf.Clamp(yRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, yRotation);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
