using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeyEnemy : MonoBehaviour
{
    public GameObject leftLimit;
    public GameObject rightLimit;
    public float speed = 3f;

    private bool movingLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = !movingLeft;
        if (movingLeft)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
        if (transform.position.x <= leftLimit.transform.position.x)
        {
            movingLeft = false;
        }

        else if (transform.position.x >= rightLimit.transform.position.x)
        {
            movingLeft = true;
        }
    }


}
