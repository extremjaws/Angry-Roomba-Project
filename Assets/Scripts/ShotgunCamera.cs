using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunCamera : MonoBehaviour
{

    public float SwayMultiplier;
    public float smoothing;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = -Input.GetAxisRaw("Mouse X") * SwayMultiplier;
        float mouseY = -Input.GetAxisRaw("Mouse Y") * SwayMultiplier;

        Vector3 finalPos = new Vector3(mouseX, mouseY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPos + initialPosition, smoothing * Time.deltaTime);
    }
}
