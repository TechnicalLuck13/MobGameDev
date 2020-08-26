using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Range(5,50)]
    public float jumpSpeed = 20f;
    [Range(5,50)]
    public float fallSpeed = 20f;
    [Range(5,50)]
    public float forwardSpeed = 10f;

    Rigidbody rb;
    bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Time since last frame = " + Time.deltaTime);

        if(Input.anyKeyDown) Jump();
        
    }
    // Fixed update is for physics it runs 50 times per second.
    void FixedUpdate()
    {
        Debug.Log("Fixed update time = " + Time.deltaTime);

        //adding forward force
        rb.AddRelativeForce(Vector3.right * forwardSpeed);

        if(isGrounded == false){
            rb.AddRelativeForce(Vector3.down * fallSpeed);
        }
    }

    void Jump(){
        if(isGrounded){
            rb.AddRelativeForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }
    }
}
