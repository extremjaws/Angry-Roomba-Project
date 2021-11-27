using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class controller : MonoBehaviour
{
    public GameObject player;
    public Vector3 targetLoc;
    public LayerMask layerMask;
    public Vector3 positionRulesNeg;
    public Vector3 positionRulesPos;

    private void Start()
    {
        Debug.Log("picked location");
        randomizeLoc();
        InvokeRepeating("check", 0, 5);
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, 10, layerMask))
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.tag == "Player")
            {
                targetLoc = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
                GetComponent<NavMeshAgent>().SetDestination(targetLoc);
                
            }
        }
        if (Vector3.Distance(transform.position, targetLoc) <= 1.5)
        {
            randomizeLoc();
        }
    }
    void check()
    {
        if (GetComponent<NavMeshAgent>().speed == 0)
        {
            randomizeLoc();
        }
    }
    void randomizeLoc()
    {
        targetLoc = new Vector3(Random.Range(player.transform.position.x - 15, player.transform.position.x + 15), transform.position.y, Random.Range(player.transform.position.z - 15, player.transform.position.z + 15));
        GetComponent<NavMeshAgent>().SetDestination(targetLoc);
    }
}
