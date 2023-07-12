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
        }
    }
}
