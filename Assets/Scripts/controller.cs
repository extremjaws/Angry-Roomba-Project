using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class controller : MonoBehaviour
{
    public GameObject player;
    public Vector3 targetLoc;
    public LayerMask layerMask;
    public float radius = 35f;
    bool aggro = false;
    AudioSource aggroSound;
    public Vector3 randomizeLoc()
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += player.transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
    void trackplayer()
    {
        aggro = true;
        targetLoc = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        GetComponent<NavMeshAgent>().SetDestination(targetLoc);
    }

    private void Start()
    {
        aggroSound = GetComponent<AudioSource>();
        targetLoc = randomizeLoc();
        GetComponent<NavMeshAgent>().SetDestination(targetLoc);
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, 15, layerMask))
        {
            if (hit.collider.tag == "Player")
            {
                if (!aggro)
                {
                    aggroSound.volume = 1;
                    trackplayer();
                }
            }
            else
            {
                aggroSound.volume = 0.1f;
                aggro = false;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, targetLoc) <= 1.5)
            {
                targetLoc = randomizeLoc();
                GetComponent<NavMeshAgent>().SetDestination(targetLoc);
            }
        }
    }
}
