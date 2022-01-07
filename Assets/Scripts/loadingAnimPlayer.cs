using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadingAnimPlayer : MonoBehaviour
{
    public async void loadnext(string level)
    {
        GetComponent<Animator>().SetTrigger("fade-in");
        await Task.Delay(1000);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadSceneAsync(level);
    }
}
