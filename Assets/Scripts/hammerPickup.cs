using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerPickup : MonoBehaviour
{
    public GameObject hammerWeapon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hammer")
        {
            other.gameObject.SetActive(false);
            hammerWeapon.SetActive(true);
        }
    }
}
