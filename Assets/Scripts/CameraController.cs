using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public Vector3 offset;
    public GameObject movingLimit;

    Vector3 targetPos;
    GameObject target;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // LateUpdate is called after Update each frame
    void FixedUpdate()
    {
        if(target.GetComponent<Rigidbody2D>().velocity.x >0 && target.transform.position.x >= movingLimit.transform.position.x)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
        }
    }
}
