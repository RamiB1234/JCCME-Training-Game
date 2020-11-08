using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObjectController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        Debug.Log("collide");
            collision.gameObject.GetComponent<PlayerController>().Goal();
            GameManager.Instance.StageComplete();
        }
    }
}
