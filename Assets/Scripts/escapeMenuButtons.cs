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
        SceneManager.LoadScene("MenuScene");
    }
    public void resume()
    {
        holder.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        paused = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            holder.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            paused = true;
        }
    }
}
