using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
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
    public int jumps = 2;
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<elevator>()) { elevatorObject = FindObjectOfType<elevator>().gameObject; }
        controller = GetComponent<CharacterController>();
        foreach (controller c in FindObjectsOfType<controller>())
        {
            c.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!noclip)
        {
            if (!controller.isGrounded)
            {
                gravity += 4.1f * Time.deltaTime;
            }
            else { 
                gravity = 0;
                jumps = 2;
            }
            if (Input.GetButtonDown("Jump") && jumps > 0)
            {
                gravity = -jumpforce;
                jumps -= 1;
            }
            if (!GetComponentInChildren<console>().consoleObject.activeSelf)
                movement = Input.GetAxisRaw("Horizontal") * transform.right + Input.GetAxisRaw("Vertical") * transform.forward;
            movement.Normalize();
            if (Input.GetKey(KeyCode.LeftShift) && sprintTime > 0)
            {
                movement = movement * 1.8f;
                if (!usprint) { sprintTime -= Time.deltaTime; }
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
