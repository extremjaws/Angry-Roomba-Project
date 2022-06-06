using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicStart : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<CinematicScript>().startCinematic();
    }
}
