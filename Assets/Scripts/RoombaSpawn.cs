using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RoombaSpawn : MonoBehaviour
{
    public int numberOfRoombas;
    public int TimeToWait;
    public Vector3 spawnPoint;
    public GameObject roombaPrefab;
    // Start is called before the first frame update
    async void Start()
    {
        await Task.Delay(TimeToWait);
        for (int i = 0; i <= numberOfRoombas; i++)
        {
            await Task.Delay(50);
            GameObject v = Instantiate(roombaPrefab);
            v.transform.position = spawnPoint;
            v.GetComponent<controller>().enabled = true;
        }
    }

}
