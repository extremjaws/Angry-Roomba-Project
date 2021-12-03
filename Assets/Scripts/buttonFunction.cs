using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonFunction : MonoBehaviour
{
    public loadingAnimPlayer loader;
    public string SceneName = "map2";

    public void Goto()
    {
        FindObjectOfType<loadingAnimPlayer>().loadnext(SceneName);
    }
}
