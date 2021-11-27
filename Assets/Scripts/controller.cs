using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class controller : MonoBehaviour
{
    public GameObject player;
    public Vector3 targetLoc;
    public LayerMask layerMask;

    private void Start()
    {
        Debug.Log("picked location");
        targetLoc = new Vector3(Random.Range(-9, 8), transform.position.y, Random.Range(0, 13));
        GetComponent<NavMeshAgent>().SetDestination(targetLoc);
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
                Debug.Log("hit!");
            }
        }
        if (Vector3.Distance(transform.position, targetLoc) <= 1)
        {
            targetLoc = new Vector3(Random.Range(-9, 8), transform.position.y, Random.Range(0, 13));
            GetComponent<NavMeshAgent>().SetDestination(targetLoc);
        }
    }
}
