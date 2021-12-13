using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    public string levelToLoad;
    public void goToNextLevel()
    {
        StartCoroutine("goUp");
    }
    IEnumerator goUp()
    {
        GetComponent<Animator>().SetTrigger("elevatorUp");
        yield return new WaitForSeconds(14);
        FindObjectOfType<loadingAnimPlayer>().loadnext(levelToLoad);    
    }
}
