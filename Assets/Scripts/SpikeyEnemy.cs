using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeyEnemy : MonoBehaviour
{
    public GameObject leftLimit;
    public GameObject rightLimit;
    public float speed = 3f;
    public int health = 10;

    private bool movingLeft = true;


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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "FireSpell")
        {
            Destroy(collision.gameObject);

            health -= 5;
            if(health<=0)
            {
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(PlayHitEffect());
            }
        }
    }

    IEnumerator PlayHitEffect()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);

    }


}
