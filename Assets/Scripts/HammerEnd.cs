using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HammerEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Respawn")
        {
            other.GetComponent<controller>().enabled = false;
            other.GetComponent<NavMeshAgent>().enabled = false;
            other.GetComponent<AudioSource>().mute = true;
            other.GetComponentInChildren<Light>().enabled = false;
            other.tag = "Untagged";
            GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f);
            GetComponent<AudioSource>().Play();
            doorManager[] doors = FindObjectsOfType<doorManager>();
            foreach (doorManager door in doors)
            {
                door.roombaCriteria -= 1;
            }
            FindObjectOfType<ModManager>().RoombaKilledEvent();
        }
    }
}
