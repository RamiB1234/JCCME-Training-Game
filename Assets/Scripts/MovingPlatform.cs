using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 1f;
    public bool isVertical = true;
    public GameObject startLimit;
    public GameObject endLimit;
    private bool allowChangeDirection=true;


    void FixedUpdate()
    {
        if (isVertical)
        {
            transform.Translate(new Vector3(0, 1 * speed, 0));
        }
        else
        {
            transform.Translate(new Vector3(1 * speed, 0, 0));
        }

        if (isVertical)
        {
            if (transform.position.y <= startLimit.transform.position.y)
            {
                if(allowChangeDirection)
                {
                    allowChangeDirection = false;
                    StartCoroutine(AllowChangingDirection());
                    speed *= -1;

                }
            }
            else if(transform.position.y >= endLimit.transform.position.y)
            {
                if (allowChangeDirection)
                {
                    allowChangeDirection = false;
                    StartCoroutine(AllowChangingDirection());
                    speed *= -1;
                }
            }
        }
        else
        {
            if (transform.position.x <= startLimit.transform.position.x)
            {
                if (allowChangeDirection)
                {
                    allowChangeDirection = false;
                    StartCoroutine(AllowChangingDirection());
                    speed *= -1;

                }
            }
            else if (transform.position.x >= endLimit.transform.position.x)
            {
                if (allowChangeDirection)
                {
                    allowChangeDirection = false;
                    StartCoroutine(AllowChangingDirection());
                    speed *= -1;
                }
            }
        }
    }

    IEnumerator AllowChangingDirection()
    {
        yield return new WaitForSeconds(0.5f);
        allowChangeDirection = true;
    }
}
