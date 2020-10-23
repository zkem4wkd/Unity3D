using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowingCamera : MonoBehaviour
{
    public float distanceAway = 7f;
    public float distanceUp = 4;

    public Transform follow;
    private void LateUpdate()
    {
        transform.position = follow.position + Vector3.up * distanceUp - Vector3.forward * distanceAway;
    }
    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
