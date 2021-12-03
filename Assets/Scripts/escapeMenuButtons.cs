using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class escapeMenuButtons : MonoBehaviour
{
    public GameObject holder;
    public static bool paused = false;
    public void menu()
    {
        paused = false;
        Time.timeScale = 1;
        FindObjectOfType<loadingAnimPlayer>().loadnext("MenuScene");
    }
    public void resume()
    {
        holder.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        paused = false;
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            holder.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            paused = true;
            Time.timeScale = 0;
        }
    }
}
