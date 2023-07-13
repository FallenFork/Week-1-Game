using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTrap : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Triggered;

    void Start()
    {
        Triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (!Triggered && other.tag == "Portkey") {
            Triggered = true;
            gameObject.transform.position = new Vector3(0f, -20f, 20f);
            Debug.Log("*** NPC: There will be a series of challenges you will have to get across to get to the treasure. Don't pay attention to the guard in front of you. There will be more along the way and they will give you instructions on what to do next. Your first challenge is to get through the maze in front of you. Good luck, and bring the treasure soon! I need to invest in more BitCoin. ***");
        }
    }
}
