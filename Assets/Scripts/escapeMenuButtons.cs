using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class escapeMenuButtons : MonoBehaviour
{
    public GameObject holder;
    public static bool paused = false;
    public void menu()
    {
        SceneManager.LoadScene("MenuScene");
        paused = false;
        Time.timeScale = 1;
    }
    public void resume()
    {
        holder.SetActive(false);
        paused = false;
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (Gamepad.current.startButton.isPressed && !paused)
        {
            holder.SetActive(true);
            paused = true;
            Time.timeScale = 0;
        }
    }
}
