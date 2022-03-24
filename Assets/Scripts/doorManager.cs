using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorManager : MonoBehaviour
{
    public int roombaCriteria;
    public int buttonCriteria = 1;
    public GameObject[] roombasToActivate;
    bool opened = false;

    private void Start()
    {
        buttonCriteria -= 1;
    }
    private void open()
    {
        opened = true;
        Debug.Log("roomba criteria met and button criteria met");
        GetComponentInChildren<Animator>().SetTrigger("OpenDoor");
        foreach (GameObject roomba in roombasToActivate)
        {
            roomba.GetComponent<controller>().activate();
            roomba.GetComponent<AudioSource>().enabled = true;
        }
    }
    private void Update()
    {
        if (roombaCriteria == 0 && buttonCriteria == 0 && !opened)
        {
            open();
        }
    }
}
