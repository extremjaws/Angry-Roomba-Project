using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPickup : MonoBehaviour
{
    public GameObject shotgunWeapon;
    public GameObject shotgunHud;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "shotgun")
        {
            other.gameObject.SetActive(false);
            shotgunWeapon.SetActive(true);
            shotgunHud.SetActive(true);
        }
    }
}
