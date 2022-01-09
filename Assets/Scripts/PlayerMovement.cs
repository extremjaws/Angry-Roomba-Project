using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    InputDevice RightHand;
    InputDevice LeftHand;
    private CharacterController controller;
    private Vector3 movement;
    private float gravity;
    public bool elevatorMotion;
    public float jumpforce = 0;
    public Vector3 spawn;
    float sprintTime = 5f;
    public GameObject sprintBar;
    public GameObject elevatorObject;
    public bool noclip;
    public bool usprint;
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<elevator>()) { elevatorObject = FindObjectOfType<elevator>().gameObject; }
        controller = GetComponent<CharacterController>();
        foreach (controller c in FindObjectsOfType<controller>())
        {
            c.enabled = true;
        }
        TryGetControllers();
    }

    void TryGetControllers()
    {

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

    // Update is called once per frame
    void Update()
    {
        if (RightHand.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 turn))
        {
            transform.Rotate(Vector3.up, turn.x * 2);
        }
        if (!noclip)
        {
            if (!controller.isGrounded)
            {
                gravity += 4.1f * Time.deltaTime;
            }
            else
            {
                gravity = 0;
                if(RightHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool pressed) && pressed)
                {
                    gravity = -jumpforce;
                }
            }
            Vector2 joypad = Vector2.zero;
            if (LeftHand.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 walk))
            {
                joypad = walk;
            }
            Vector3 right = Camera.main.transform.right;
            right.y = 0;
            right.Normalize();
            Vector3 forward = Camera.main.transform.forward;
            forward.y = 0;
            right.Normalize();
            if (!GetComponentInChildren<console>().consoleObject.activeSelf)
                movement = joypad.x * right + joypad.y * forward;
            movement.Normalize();
            if (RightHand.TryGetFeatureValue(CommonUsages.secondaryButton, out bool sprint) && sprint && sprintTime > 0)
            {
                movement = movement * 1.8f;
                if (!usprint) { sprintTime -= Time.deltaTime; }
                updateSprintBarFill();
            }
            else
            {
                if (RightHand.TryGetFeatureValue(CommonUsages.secondaryButton, out sprint) && !sprint && sprintTime < 5)
                {
                    sprintTime += Time.deltaTime / 2;
                    updateSprintBarFill();
                }
                if (sprintTime > 5)
                {
                    sprintTime = 5;
                }

            }

            movement += Vector3.down * gravity;
            controller.Move(movement * Time.deltaTime * 4);
            if (transform.position.y <= -50)
            {
                transform.position = spawn;
            }
            if (elevatorMotion)
            {
                transform.position = elevatorObject.transform.position;
            }
        }
        else
        {

            if (!GetComponentInChildren<console>().consoleObject.activeSelf)
                movement = GetComponentInChildren<Camera>().transform.forward * Input.GetAxisRaw("Vertical") + GetComponentInChildren<Camera>().transform.right * Input.GetAxisRaw("Horizontal");
            else
                movement = Vector3.zero;
            movement.Normalize();
            controller.Move(movement * Time.deltaTime * 20f);
        }
    }
    void updateSprintBarFill()
    {
        float barfill = sprintTime / 5;
        sprintBar.transform.localScale = new Vector3(barfill, 1.0f, 1.0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            elevatorMotion = true;
            FindObjectOfType<elevator>().goUp();
        }
    }

}
