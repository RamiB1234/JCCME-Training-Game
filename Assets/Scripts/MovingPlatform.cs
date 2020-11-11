using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 1f;
    public bool isVertical = true;
    public GameObject startLimit;
    public GameObject endLimit;
    private bool allowChangeDirection=true;

    void Start()
    {
        if(isVertical)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1 * speed);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1 * speed, 0);
        }
    }

    void Update()
    {
        if (isVertical)
        {
            if (transform.position.y <= startLimit.transform.position.y ||
                transform.position.y >= endLimit.transform.position.y)
            {
                if(allowChangeDirection)
                {
                    StartCoroutine(ReverseDrection());
                    allowChangeDirection = false;
                    StartCoroutine(AllowChangingDirection());
                }
            }
        }
        else
        {
            if (transform.position.x <= startLimit.transform.position.x ||
                transform.position.x >= endLimit.transform.position.x)
            {
                if (allowChangeDirection)
                {
                    StartCoroutine(ReverseDrection());
                    allowChangeDirection = false;
                    StartCoroutine(AllowChangingDirection());
                }
            }
        }
    }

    IEnumerator ReverseDrection()
    {
        var originalVel = GetComponent<Rigidbody2D>().velocity;

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(0.35f);
        GetComponent<Rigidbody2D>().velocity = originalVel;
        GetComponent<Rigidbody2D>().velocity *= -1;
    }

    IEnumerator AllowChangingDirection()
    {
        yield return new WaitForSeconds(0.5f);
        allowChangeDirection = true;
    }
}
