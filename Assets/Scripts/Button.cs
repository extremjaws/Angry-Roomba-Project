using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Button : MonoBehaviour
{
    Transform player;
    GameObject eTip;
    GameObject eTipTemp;
    CanvasGroup eTipAlpha;
    Animator eTipAnimator;
    public GameObject doorToActivate;
    public bool inRange = false;
    public float range;
    public bool activated = false;
    // Start is called before the first frame update

    private GameObject FindChildByName(GameObject topParent, string gameObjectName)
    {
        for (int i = 0; 1 < topParent.transform.childCount; i++)
        {
            if (topParent.transform.GetChild(i).name == gameObjectName)
            {
                return topParent.transform.GetChild(i).gameObject;
            }
        }
        return null;
    }
    void Awake()
    {
        doorToActivate.GetComponent<doorManager>().buttonCriteria += 1;
    }
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        eTipTemp = FindChildByName(player.gameObject, "Canvas");
        eTip = FindChildByName(eTipTemp, "e");
        eTipAlpha = eTip.GetComponent<CanvasGroup>();
        eTipAnimator = eTip.GetComponent<Animator>();
    }

    async void EPress()
    {
        eTipAnimator.SetTrigger("Press");
        GetComponent<Animator>().SetTrigger("Press");
        activated = true;
        await Task.Delay(650);
        eTip.GetComponent<CanvasGroup>().alpha = 0;
        enabled = false;
        //eTip.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= range && inRange == false) {
            inRange = true;
        } else if (Vector3.Distance(player.position, transform.position) >= range && inRange == true) {
            inRange = false;
        } else if (inRange) {
            eTipAlpha.alpha = 1 - Vector3.Distance(player.position, transform.position) / range;
        }
        if (Input.GetKeyDown("e") && inRange && !activated)
        {
            EPress();
            doorToActivate.GetComponent<doorManager>().buttonCriteria -= 1;
        }
    }

}
