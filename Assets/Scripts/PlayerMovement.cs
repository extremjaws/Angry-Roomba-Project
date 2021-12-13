using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;
    private float gravity;
    private bool elevatorMotion;
    public float jumpforce = 0;
    public Vector3 spawn;
    float sprintTime = 5f;
    public GameObject sprintBar;
    public GameObject elevatorObject;
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<elevator>()) { elevatorObject = FindObjectOfType<elevator>().gameObject; }
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
            updateSprintBarFill();
        }
        else
        {
            if (!Input.GetKey(KeyCode.LeftShift) && sprintTime < 5)
            {
                sprintTime += Time.deltaTime / 2;
                updateSprintBarFill();
            }
            if (sprintTime > 5)
            {
                sprintTime = 5;
            }

        }

        controller.Move(movement * Time.deltaTime * 4);
        if (transform.position.y <= -50)
        {
            transform.position = spawn;
        }
        if (elevatorMotion)
        {
            transform.position = new Vector3(transform.position.x, elevatorObject.transform.position.y, transform.position.z);
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
            FindObjectOfType<elevator>().goToNextLevel();
        }
    }

}
