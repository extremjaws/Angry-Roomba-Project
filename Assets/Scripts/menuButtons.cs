using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menuButtons : MonoBehaviour
{
    public GameObject mainpanel;
    public GameObject settingsPanel;
    public GameObject selectorPanel;
    public GameObject holder;
    public void quit()
    {
        Application.Quit();
    }

    public void SelectMenu(int menu)
    {
        holder.GetComponent<RectTransform>().localPosition = new Vector2(0, menu * 1080);
    }
}
