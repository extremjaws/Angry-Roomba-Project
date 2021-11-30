using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;
    private float gravity;
    public float jumpforce = 0;
    public Vector3 spawn;
    float sprintTime = 5f;
    public GameObject sprintBar;
    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!controller.isGrounded)
        {
            gravity += 4.1f * Time.deltaTime;
        }
        else
        {
            gravity = 0;
            if (Gamepad.current.buttonSouth.isPressed)
            {
                gravity = -jumpforce;
            }
        }
        Vector2 joyvalue = Gamepad.current.leftStick.ReadValue();
        movement = joyvalue.x * transform.right + joyvalue.y * transform.forward + Vector3.down * gravity;
        movement.Normalize();
        if (Gamepad.current.buttonWest.isPressed && sprintTime > 0)
        {
            movement = movement * 1.8f;
            sprintTime -= Time.deltaTime;
            updateSprintBarFill();
        }
        else
        {
            if (!Gamepad.current.buttonWest.isPressed && sprintTime < 5)
            {
                sprintTime += Time.deltaTime / 2;
                updateSprintBarFill();
            }
            if (sprintTime > 5) { 
                sprintTime = 5;
            }
            
        }

        controller.Move(movement * Time.deltaTime * 4);
        if (transform.position.y <= -50)
        {
            transform.position = spawn;
        }
    }
    void updateSprintBarFill()
    {
        float barfill = sprintTime / 5;
        sprintBar.transform.localScale = new Vector3(barfill, 1.0f, 1.0f);
    }


}
