using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sincosTest : MonoBehaviour
{
    public GameObject Prefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 22; i++)
        {
            GameObject obj = Instantiate(Prefab);
            obj.transform.parent = transform;
            float rot = Random.Range(0, 360);
            obj.GetComponent<RectTransform>().localPosition = new Vector2(Mathf.Cos(rot), Mathf.Sin(rot)) * Random.Range(0,100);
            Debug.Log(obj.GetComponent<RectTransform>().localPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
