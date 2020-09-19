using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TankShell : MonoBehaviour
{
    InputManager mgr;

    // Start is called before the first frame update
    void Start()
    {
        mgr = GameObject.Find("Input Manager").GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Enemy")){
            Destroy(other.gameObject);
            mgr.UpdateScore(1000);
        }
        Destroy(this.gameObject);
        Destroy(this);
    }
}
