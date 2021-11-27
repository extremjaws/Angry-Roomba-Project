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
            controller.Move(movement * Time.deltaTime * 4);
        if (transform.position.y <= -50)
        {
            transform.position = spawn;
        }
    }
    

}
