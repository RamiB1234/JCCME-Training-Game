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
        Application.targetFrameRate = 60;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // LateUpdate is called after Update each frame
    void FixedUpdate()
    {
        Vector3 posNoZ = transform.position;

        posNoZ.z = target.transform.position.z;

        Vector3 targetDirection = (target.transform.position - posNoZ);

        if ((target.GetComponent<Rigidbody2D>().velocity.x >0 && target.transform.position.x >= movingLimit.transform.position.x)
            || (target.transform.parent != null && (target.transform.parent.tag == "MovingPlatform")))
        {



            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
        }
        else
        {
            // Lerp Y
            var lerpYPos = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
            posNoZ.z = lerpYPos.z;
            targetDirection = (lerpYPos - posNoZ);

            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
        }
    }
}
