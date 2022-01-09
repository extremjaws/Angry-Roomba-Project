using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorManager : MonoBehaviour
{
    public int roombaCriteria;
    public GameObject[] roombasToActivate;
    bool opened = false;
    private void Update()
    {
        if (roombaCriteria == 0 && !opened)
        {
            opened = true;
            Debug.Log("roomba criteria met");
            GetComponentInChildren<Animator>().SetTrigger("OpenDoor");
            foreach (GameObject roomba in roombasToActivate)
            {
                roomba.GetComponent<controller>().activate();
                roomba.GetComponent<AudioSource>().enabled = true;
            }
        }
    }
}
