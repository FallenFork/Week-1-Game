using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardCombatController : MonoBehaviour
{
    // Start is called before the first frame update
    UnityEngine.AI.NavMeshAgent agent;
    public GameObject[] waypoints = new GameObject[2];

    public GameObject prefabPaintball;
    public GameObject muzzle;
    public int attackRange = 15;
    public float fireRate = 2f;
    public float ballSpeed = 2000f;
    
    public enum GuardState {
        Waypoint, MoveToWaypoint, 
    }

    public int viewRange = 20;
    public GuardState state = GuardState.Waypoint;
    public int currentWaypoint = 0;
    public GameObject target;
    public bool playerInAttackRange;
    public float lastFire = 0f;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        state = GuardState.Waypoint;
        currentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameState();
        Attack();
    }

    void CheckGameState() {
        lastFire += Time.deltaTime;
        playerInAttackRange = PlayerInAttackRange();

        switch (state) {
            case GuardState.Waypoint:
                Waypoint();
                break;
            case GuardState.MoveToWaypoint:
                MoveToWaypoint();
                break;
            default:
                Debug.Log("Error: invalid state");
                break;
        }
    }

    public GameObject FindClosestTarget(string tag, float maxDistance) {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = null;

        float distance = maxDistance * maxDistance;
        Vector3 position = transform.position;

        foreach (GameObject obj in gameObjects) {
            Vector3 difference = obj.transform.position - position;
            float curDistance = difference.sqrMagnitude;

            if (curDistance < distance) {
                closest = obj;
                distance = curDistance;
            }
        }
        return closest;
    }

    public bool PlayerInRange() {
        target = FindClosestTarget("Player", viewRange);
        return target != null;
    }

    public void Waypoint() {
        currentWaypoint += 1;
        if (currentWaypoint >= waypoints.Length) {
            currentWaypoint = 0;
        }
        agent.SetDestination(waypoints[currentWaypoint].transform.position);
        state = GuardState.MoveToWaypoint;
    }

    public void MoveToWaypoint() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Waypoint") {
            if (state == GuardState.MoveToWaypoint) {
                state = GuardState.Waypoint;
            }
        }
    }

    public bool PlayerInAttackRange() {
        target = FindClosestTarget("Player", attackRange);
        return target != null;
    }

    public void Attack() {
        transform.LookAt(target.transform);
        if (lastFire >= fireRate) {
            GameObject ball = Object.Instantiate(prefabPaintball, muzzle.transform.position, Quaternion.identity);
            Rigidbody rigidBody = ball.GetComponent<Rigidbody>();
            rigidBody.AddForce(transform.forward * ballSpeed);
            lastFire = 0;
        } 
    }
}
