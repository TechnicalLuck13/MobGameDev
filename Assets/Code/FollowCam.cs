//Jake Whimter
// follow players x but not anything else

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [Tooltip("The object you want to follow")]
    public Transform target;

    //strarting pos of camera
    Vector3 startPos;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // get pos of target but keep starting y and z
        Vector3 newPos = new Vector3(target.position.x, startPos.y, startPos.z);
        this.transform.position = newPos;
    }
}
