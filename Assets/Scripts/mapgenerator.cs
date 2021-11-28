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

    private void Start()
    {
        MapsArea.GetComponent<RectTransform>().sizeDelta = new Vector2(MapsArea.GetComponent<RectTransform>().sizeDelta.x, Maps.maps.Length * 50);
        int i = 0;
        foreach (MapListio.Map map in Maps.maps)
        {
            GameObject mapButton = Instantiate(MapTemplate);
            mapButton.GetComponentsInChildren<Image>()[1].sprite = map.MapPreview;
            mapButton.GetComponentInChildren<TMP_Text>().text = map.MapName;
            mapButton.transform.parent = MapsArea.transform;
            mapButton.GetComponent<RectTransform>().localPosition = new Vector3(-1149 / 2, 400 + 50 * i, 0);
            mapButton.GetComponent<RectTransform>().sizeDelta = new Vector2(1149, 50);
            i++;
        }
    }
}
