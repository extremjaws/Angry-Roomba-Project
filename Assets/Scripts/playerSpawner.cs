using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerSpawner : MonoBehaviour
{
    GameObject player;
    bool setplayerpos = false;
    public GameObject[] objectsToActivate;
    // Start is called before the first frame update
    void Awake()
    {
        loadPlayerContainer();
    }
    async Task loadPlayerContainer()
    {
        if (!FindObjectOfType<PlayerMovement>())
        {
            SceneManager.LoadScene("playerContainer", LoadSceneMode.Additive);
            if (objectsToActivate.Length != 0)
            {
                foreach (GameObject o in objectsToActivate)
                {
                    o.SetActive(true);
                }
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (!player)
        {
            player = FindObjectOfType<PlayerMovement>().gameObject;
            setplayerpos = true;
        }
        else if (setplayerpos)
        {
            Debug.Log(transform.parent.position);
            player.transform.position = transform.parent.position;
            setplayerpos = false;
            gameObject.SetActive(false);
        }
    }
}
