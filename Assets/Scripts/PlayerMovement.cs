using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;
    private float gravity;
    public float jumpforce = 0;
    public Vector3 spawn;
    float sprintTime = 5f;
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
            if (Input.GetButton("Jump"))
            {
                gravity = -jumpforce;
            }
        }
        movement = Input.GetAxisRaw("Horizontal") * transform.right + Input.GetAxisRaw("Vertical") * transform.forward + Vector3.down * gravity;
        movement.Normalize();
        if (Input.GetKey(KeyCode.LeftShift) && sprintTime > 0)
        {
            movement = movement * 1.8f;
            sprintTime -= Time.deltaTime;
        }
        else
        {
            if (!Input.GetKey(KeyCode.LeftShift) && sprintTime < 5)
            {
                sprintTime += Time.deltaTime / 2;
            }
            if (sprintTime > 5) { sprintTime = 5; }
        }

        controller.Move(movement * Time.deltaTime * 4);
        if (transform.position.y <= -50)
        {
            transform.position = spawn;
        }
    }


}
