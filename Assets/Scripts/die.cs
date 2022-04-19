using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class die : MonoBehaviour
{
    public GameObject deathUI;
    public bool god;
    private bool dead = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn" && !god && !dead)
        {
            dead = true;
            deathUI.SetActive(true);
            GetComponent<PlayerMovement>().enabled = false;
            Invoke("respawn", 3);
        }
    }
    void respawn()
    {
        FindObjectOfType<loadingAnimPlayer>().loadnext(SceneManager.GetActiveScene().name);
    }
}
