using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorManager : MonoBehaviour
{
    public int roombaCriteria;
    private void Update()
    {
        if (roombaCriteria == 0)
        {
            Debug.Log("roomba criteria met");
            GetComponentInChildren<Animator>().SetTrigger("OpenDoor");
        }
    }
}
