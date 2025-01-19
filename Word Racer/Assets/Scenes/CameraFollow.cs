using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform playerTransform;
    public Transform playerTransform1;
    public Transform playerTransform2;
    public Vector3 offset;
    public float forwardSpeed = 5;
   
    void Start()
    {
        forwardSpeed = 25f;
    }
    void LateUpdate()
    {
        playerTransform = playerTransform1.gameObject.activeInHierarchy ? playerTransform1 : playerTransform2;
        Follow();
    }

    public void Follow()
    {
        Vector3 currentPos = transform.position;
        
        Vector3 newPos = new Vector3(playerTransform.position.x + offset.x, playerTransform.position.y + offset.y, playerTransform.position.z + offset.z);

        transform.position = Vector3.Lerp(currentPos, newPos, Time.deltaTime * forwardSpeed );
    }
}


