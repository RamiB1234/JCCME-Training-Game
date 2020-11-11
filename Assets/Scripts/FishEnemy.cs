using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishEnemy : MonoBehaviour
{
    public GameObject topLimit;
    public GameObject bottomLimit;
    public float speed = 3f;
    public int health = 10;

    private bool movingUp = true;


    // Update is called once per frame
    void Update()
    {
        if (movingUp)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            GetComponent<SpriteRenderer>().transform.rotation= Quaternion.Euler(Vector3.forward * -90);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            GetComponent<SpriteRenderer>().transform.rotation = Quaternion.Euler(Vector3.forward * 90);
        }
        if (transform.position.y >= topLimit.transform.position.y)
        {
            movingUp = false;
        }

        else if (transform.position.y <= bottomLimit.transform.position.y)
        {
            movingUp = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "FireSpell")
        {
            Destroy(collision.gameObject);

            health -= 5;
            if (health <= 0)
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
