using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorManager : MonoBehaviour
{
    public int roombaCriteria;
    public GameObject[] roombasToActivate;
    private void Update()
    {
        if (roombaCriteria == 0)
        {
            Debug.Log("roomba criteria met");
            GetComponentInChildren<Animator>().SetTrigger("OpenDoor");
            foreach (GameObject roomba in roombasToActivate)
            {
                roomba.GetComponent<controller>().enabled = true;
                roomba.GetComponent<AudioSource>().enabled = true;
            }
        }
    }
}
