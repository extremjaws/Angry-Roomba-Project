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
    public GameObject playerSnapObj;
    public async void goUp()
    {
        GetComponent<Animator>().SetTrigger("elevatorUp");
        //yield return new WaitForSeconds(12);
        SceneManager.LoadSceneAsync(levelToLoad, LoadSceneMode.Additive);
        FindObjectOfType<PlayerMovement>().elevatorObject = playerSnapObj;
        FindObjectOfType<PlayerMovement>().elevatorMotion = true;
        await Task.Delay(15000);
        FindObjectOfType<PlayerMovement>().elevatorMotion = false;
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
