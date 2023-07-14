using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardMovementControllerRight : MonoBehaviour
{
    // Start is called before the first frame update
    public  GameObject[] waypoints = new GameObject[2];
    public int currentWaypoint;
    NavMeshAgent agent;

    
    void Start()
    {
        currentWaypoint = -1;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        move();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void move(){
        currentWaypoint += 1;
        if(currentWaypoint >= waypoints.Length){
            currentWaypoint = 0;
        }
        agent.SetDestination(waypoints[currentWaypoint].transform.position);
    }

    IEnumerator OnTriggerEnter(Collider other){
        if(other.tag == "WaypointRight"){
            move();
        }
        yield return new WaitForSeconds(3);
            }


    
}
