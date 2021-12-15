using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    public string levelToLoad;
    public bool isStart;
    private void Start()
    {
        if (isStart)
        {
            StartCoroutine("startLevel");
        }
    }
    public void goToNextLevel()
    {
        StartCoroutine("goUp");
    }
    IEnumerator goUp()
    {
        GetComponent<Animator>().SetTrigger("elevatorUp");
        yield return new WaitForSeconds(12);
        FindObjectOfType<loadingAnimPlayer>().loadnext(levelToLoad);    
    }
    IEnumerator startLevel()
    {
        FindObjectOfType<PlayerMovement>().elevatorMotion = true;
        GetComponent<Animator>().SetTrigger("elevatorStart");
        yield return new WaitForSeconds(12);
        FindObjectOfType<PlayerMovement>().elevatorMotion = false;
    }
}
