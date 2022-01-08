using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class unloadDoorController : MonoBehaviour
{
    public GameObject door;
    public string sceneToUnload;
    async void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            door.GetComponent<Animator>().SetTrigger("CloseDoor");
            await Task.Delay(2000);
            SceneManager.UnloadSceneAsync(sceneToUnload);
        }
    }
}
