using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 offset;
    public Transform playerTransform;
    void Start()
    {
        offset = transform.position - playerTransform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + playerTransform.position;
    }
}
