using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class elevator : MonoBehaviour
{
    public string levelToLoad;
    public bool isStart;
    public GameObject[] roombasToActivate;
    public GameObject elevatorTrigger;
    public void goToNextLevel()
    {
        goUp();
    }
    async void goUp()
    {
        GetComponent<Animator>().SetTrigger("elevatorUp");
        //yield return new WaitForSeconds(12);
        await Task.Delay(15000);
        SceneManager.LoadSceneAsync(levelToLoad, LoadSceneMode.Additive); 
    }
    //async void startLevel()
    //{
    //    FindObjectOfType<PlayerMovement>().elevatorMotion = true;
    //    GetComponent<Animator>().SetTrigger("elevatorStart");
    //    //yield return new WaitForSeconds(12);
    //    await Task.Delay(15000);
    //    FindObjectOfType<PlayerMovement>().elevatorMotion = false;
    //    foreach (GameObject roomba in roombasToActivate)
    //    {
    //        roomba.GetComponent<controller>().enabled = true;
    //    }
    //}
}
