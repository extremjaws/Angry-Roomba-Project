using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class die : MonoBehaviour
{
    public GameObject deathUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            deathUI.SetActive(true);
            GetComponent<PlayerMovement>().enabled = false;
            Invoke("respawn", 3);
        }
    }
    void respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
