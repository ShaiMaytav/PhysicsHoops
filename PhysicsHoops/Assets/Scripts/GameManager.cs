using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private CollisionManager collisionManager;
    [SerializeField] Text scoreText;
    private int score = 0;
    private void Start()
    {
        collisionManager = GetComponent<CollisionManager>();
    }

    private void FixedUpdate()
    {
        if (collisionManager.CheckCol())
        {
            Debug.Log("col");
        }
    }

    void HandleScore()
    {

    }
}
