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
            if (Physics.Raycast(raycastStart.transform.position, raycastStart.transform.TransformDirection(Vector3.forward), out hit, 2.5f, layerMask))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.tag == "Respawn")
                {
                    StartCoroutine(hammer(0.25f, hit));
                }
            }
        }
    }
    IEnumerator hammer(float time, RaycastHit hit)
    {
        yield return new WaitForSeconds(time);
        hit.collider.GetComponent<controller>().enabled = false;
        hit.collider.GetComponent<NavMeshAgent>().enabled = false;
        hit.collider.GetComponent<AudioSource>().mute = true;
        GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f);
        GetComponent<AudioSource>().Play();
    }
}