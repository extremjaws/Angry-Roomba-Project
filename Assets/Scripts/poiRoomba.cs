using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class poiRoomba : MonoBehaviour
{
    public GameObject[] pois;
    public Vector3 destination;
    public int index = 0;
    public LayerMask layerMask;
    public GameObject player;
    bool aggro;
    public AudioSource aggroSound;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(pois[0].transform.position);
        destination = pois[0].transform.position;
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }
    void trackplayer()
    {

        aggro = true;
        destination = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        GetComponent<NavMeshAgent>().SetDestination(destination);

    }

    // Update is called once per frame
    void Update()
    {
        //if (index >= pois.Length) { index = 0; }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, 6, layerMask))
        {
            if (hit.collider.tag == "Player")
            {
                if (aggroSound.volume < 2f)
                {
                    aggroSound.volume += 2 * Time.deltaTime;
                }
                if (!aggro)
                {
                    trackplayer();
                }
            }
            else
            {
                if (aggroSound.volume > 0.5f)
                {
                    aggroSound.volume -= 2 * Time.deltaTime;
                }
                aggro = false;
            }

        }
        if (Vector3.Distance(transform.position, destination) <= 0.5f)
        {
            GetComponent<NavMeshAgent>().SetDestination(pois[index].transform.position);
            destination = pois[index].transform.position;
            index++;
        }
        else
        {
            GetComponent<NavMeshAgent>().SetDestination(pois[index].transform.position);
            destination = pois[index].transform.position;
        }
        if (index >= pois.Length) { index = 0; }
        Debug.Log(index);
    }
}
