using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

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
        rb.AddRelativeForce(Vector3.right * 10);
    }

    void Jump(){
        rb.AddRelativeForce(Vector3.up * 20, ForceMode.Impulse);
    }
}
