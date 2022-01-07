using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    async void Awake()
    {
        try 
        { 
            await loadPlayerContainer();
        }
        finally 
        { 
            gameObject.SetActive(false);
            FindObjectOfType<PlayerMovement>().transform.position = transform.position;
        } 
    }
    async Task loadPlayerContainer()
    {
        SceneManager.LoadSceneAsync("playerContainer", LoadSceneMode.Additive);
    }
}
