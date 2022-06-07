using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class unloadDoorController : MonoBehaviour
{
    public GameObject door;
    public string sceneToUnload;
    public GameObject[] roombasToActivate;
    public GameObject[] objectsToDeactivate;
    async void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (roombasToActivate.Length != 0)
            {
                foreach (GameObject roomba in roombasToActivate)
                {
                    roomba.GetComponent<controller>().activate();
                }
            }
            door.GetComponent<Animator>().SetTrigger("close");
            await Task.Delay(2000);
            if (objectsToDeactivate.Length != 0)
            {
                foreach (GameObject o in objectsToDeactivate)
                {
                    o.SetActive(false);
                }
            }
            SceneManager.UnloadSceneAsync(sceneToUnload);
            gameObject.SetActive(false);
        }
    }
}
