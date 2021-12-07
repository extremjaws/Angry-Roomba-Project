using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class hammerWeapon : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject raycastStart;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            GetComponent<Animator>().SetTrigger("SwingHammer");
            RaycastHit hit;
            if (Physics.Raycast(raycastStart.transform.position, raycastStart.transform.TransformDirection(Vector3.forward), out hit, 5, layerMask))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.tag == "Respawn")
                {
                    hit.collider.GetComponent<controller>().enabled = false;
                    hit.collider.GetComponent<NavMeshAgent>().enabled = false;
                }
            }
        }
    }
}