using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverObject;
    public GameObject stageCompleteObject;

    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }
    
    public void GameOver()
    {
        gameOverObject.SetActive(true);
    }

    public void StageComplete()
    {
        stageCompleteObject.SetActive(true);
    }
}
