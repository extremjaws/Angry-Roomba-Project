using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mapgenerator : MonoBehaviour
{
    public GameObject MapTemplate;
    public GameObject MapsArea;
    public MapListio Maps;
    int pos = 0;

    private void Start()
    {
        Debug.Log("start");
        //MapsArea.GetComponent<RectTransform>().sizeDelta = new Vector2(MapsArea.GetComponent<RectTransform>().sizeDelta.x, Maps.maps.Length * 50);
        int i = 0;
        foreach (MapListio.Map map in Maps.maps)
        {
            GameObject mapButton = Instantiate(MapTemplate);
            mapButton.GetComponentsInChildren<Image>()[1].sprite = map.MapPreview;
            mapButton.GetComponentInChildren<TMP_Text>().text = map.MapName;
            mapButton.transform.SetParent(MapsArea.transform, false);
            mapButton.GetComponent<RectTransform>().localPosition = new Vector3(0, pos, 0);
            //mapButton.GetComponent<RectTransform>().localPosition = new Vector3(-1149 / 2, 400 + 50 * i, 0);
            //mapButton.GetComponent<RectTransform>().sizeDelta = new Vector2(1149, 50);
            pos -= 50;
            i++;
            Debug.Log(mapButton);
        }
    }
}
