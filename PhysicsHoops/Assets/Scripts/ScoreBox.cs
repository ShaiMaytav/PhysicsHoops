using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBox : MonoBehaviour
{
    MyPhysics ball;
    MyBoxCollider coll;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<MyPhysics>();
        coll = GetComponent<MyBoxCollider>();
        startPos = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (coll.didCollide)
        {
            GameManager.Instance.score++;
            ball.ResetValues();
            ball.transform.position = startPos;
            Debug.Log("Score");
            ball.enabled = false;
            coll.didCollide = false;
        }
    }
}
