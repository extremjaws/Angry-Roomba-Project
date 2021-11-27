using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class controller : MonoBehaviour
{
    public GameObject player;
    public Vector3 targetLoc;
    public LayerMask layerMask;
    public float radius = 20f;
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

    private void Start()
    {
        Debug.Log("picked location");
        targetLoc = randomizeLoc();
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
                
            }
        }
        if (Vector3.Distance(transform.position, targetLoc) <= 1.5)
        {
            targetLoc = randomizeLoc();
            GetComponent<NavMeshAgent>().SetDestination(targetLoc);
        }
    }
}
