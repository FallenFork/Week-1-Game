using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardMove : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigidBody;

    float moveSpeed = 5;
    float rotationSpeed = 100;
    /*
    float jumpForce = 400;
    bool isJumping = false;
    */

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            transform.position += moveSpeed * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)){
            transform.Rotate(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.S)){
            transform.position += -moveSpeed * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)){
            transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
        }
        /*
        if(Input.GetKeyDown(KeyCode.Space)){
            if(!isJumping){
                isJumping = true;

                rigidBody.AddForce(transform.up * jumpForce);
            }
        }
        */
    }

    /*
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "GameOver"){
            Debug.Log("Player wins!");
        }

        isJumping = false;
    }
    */
}