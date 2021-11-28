using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menuButtons : MonoBehaviour
{
    public GameObject mainpanel;
    public GameObject settingsPanel;
    public GameObject selectorPanel;
    public void quit()
    {
        Application.Quit();
    }
    public void settings()
    {
        mainpanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void noMoreSettings()
    {
        settingsPanel.SetActive(false);
        mainpanel.SetActive(true);
    }
    public void loadMap(string mapName)
    {
        SceneManager.LoadScene(mapName);
    }
}
