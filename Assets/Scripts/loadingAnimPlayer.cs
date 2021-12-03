using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadingAnimPlayer : MonoBehaviour
{
    public void loadnext(string level)
    {
       StartCoroutine(LoadLevel(level));
    }

    IEnumerator LoadLevel(string level)
    {
        GetComponent<Animator>().SetTrigger("fade-in");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(level);
    }
}
