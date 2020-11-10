using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    private Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.localPosition;
        StartCoroutine(AddForce());
        StartCoroutine(ResetPos());
    }

    IEnumerator AddForce()
    {
        while(true)
        {
            var randSpeed = UnityEngine.Random.Range(0.5f, 3.0f);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-35 * randSpeed, 67 * randSpeed));
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator ResetPos()
    {
        while(true)
        {
            var rand = UnityEngine.Random.Range(3.0f, 5.0f);
            yield return new WaitForSeconds(rand);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transform.localPosition = initialPos;
        }
    }
}
