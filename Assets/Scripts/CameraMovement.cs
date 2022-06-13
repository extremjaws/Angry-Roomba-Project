using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float SensitivityX;
    public float SensitivityY;
    public Transform playerBody;

    private float mouseX = 0.0f;
    private float mouseY = 0.0f;
    private float xRotation = 0f;
    private float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<Camera>().enabled = true;
        GetComponent<AudioListener>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (consoleVII.open)
            return;
        mouseX = Input.GetAxis("Mouse X") * SensitivityX;
        mouseY = Input.GetAxis("Mouse Y") * SensitivityY;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        yRotation = Mathf.Clamp(yRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, yRotation);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
