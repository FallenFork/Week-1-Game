using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardCombatController : MonoBehaviour
{
    public GameObject prefabPaintball;
    public GameObject muzzle;
    public float fireRate = 2f;
    public float ballSpeed = 2000f;
    public float lastFire = 0f;
    public bool startFiring = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameState();
    }

    void CheckGameState() {
        lastFire += Time.deltaTime;
        if(startFiring){
            Attack();
        }
    }

    public void Attack(){
        transform.LookAt(GameObject.FindWithTag("Player").transform);
        if (lastFire >= fireRate) {
            GameObject ball = Object.Instantiate(prefabPaintball, muzzle.transform.position, Quaternion.identity);
            Rigidbody rigidBody = ball.GetComponent<Rigidbody>();
            rigidBody.AddForce(transform.forward * ballSpeed);
            lastFire = 0;
        } 
    }

   
}
