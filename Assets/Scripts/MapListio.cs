using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapList", menuName = "ScriptableObjects/MapList", order = 1)]
public class MapListio : ScriptableObject
{
    [System.Serializable]
    public struct Map
    {
        public string MapName;
        public string SceneName;
        public Sprite MapPreview;
    }
    public Map[] maps;
}
