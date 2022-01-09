using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    InputDevice RightHand;
    InputDevice LeftHand;
    CharacterController controller;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        List<InputDevice> inputDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, inputDevices);
        if (inputDevices.Count <= 0)
        {
            Debug.LogError("Unable to find right contoller");
        }
        else
        {
            RightHand = inputDevices[0];
        }
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, inputDevices);
        if (inputDevices.Count <= 0)
        {
            Debug.LogError("Unable to find left contoller");
        }
        else
        {
            LeftHand = inputDevices[0];
        }
    }
    void Update()
    {
        if (RightHand.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 walk))
        {
            Vector3 movement = -Vector3.up;
            Vector3 temp = Camera.main.transform.forward * walk.y;
            temp += Camera.main.transform.right * walk.x;
            temp.y = 0;
            temp.Normalize();
            if(LeftHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool run))
            {
                if(run)
                {
                    temp *= 4;
                }
            }
            movement += temp;
            controller.Move(movement * Time.deltaTime);
        }
        if (LeftHand.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 turn))
        {
            transform.Rotate(Vector3.up, turn.x * 90 * Time.deltaTime);
        }
    }
}
