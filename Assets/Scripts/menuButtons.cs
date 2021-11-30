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
    int CurrentMenu = -1;

    public void Update()
    {
        holder.GetComponent<RectTransform>().localPosition = new Vector2(0, Mathf.Lerp(holder.GetComponent<RectTransform>().localPosition.y, CurrentMenu * 1080, Time.deltaTime * 8));
    }
    public void quit()
    {
        Application.Quit();
    }

    public void SelectMenu(int menu)
    {
        CurrentMenu = menu;
    }
}
