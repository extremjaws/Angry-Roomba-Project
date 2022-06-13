using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CinematicScript : MonoBehaviour
{
    [System.Serializable] public struct Event
    {
        public string eventName;
        public GameObject eventObject;
        public float eventTime;
    }
    public float cinematicEnd;

    public List<Event> Events = new List<Event>();
    public GameObject cinematicTrigger;

    PlayerMovement CharacterController;
    Camera mainCamera;

    private void Start()
    {
        CharacterController = FindObjectOfType<PlayerMovement>();
        mainCamera = Camera.main;
    }
    public void startCinematic()
    {
        GetComponent<Camera>().enabled = true;
        mainCamera.enabled = false;
        CharacterController.enabled = false;
        GetComponent<Animator>().SetTrigger("cinematic");
        for (int i = 0; i < Events.Count; i++)
        {
            eventStart(i, false);
        }
        eventStart(0, true);
    }

    async void eventStart(int index, bool isEnd)
    {
        if (!isEnd)
        {
            await Task.Delay((int)(Events[index].eventTime * 1000 / Time.timeScale));
            Events[index].eventObject.GetComponent<Animator>().SetTrigger(Events[index].eventName);
        }
        else
        {
            await Task.Delay((int)(cinematicEnd * 1000 / Time.timeScale));
            GetComponent<Camera>().enabled = false;
            mainCamera.enabled = true;
            CharacterController.enabled = true;
            cinematicTrigger.SetActive(false);
        }
    }
}
