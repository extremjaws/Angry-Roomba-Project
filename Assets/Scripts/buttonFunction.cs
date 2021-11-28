using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonFunction : MonoBehaviour
{
    public string SceneName = "map2";

    public void Goto()
    {
        SceneManager.LoadScene(SceneName);
    }
}
