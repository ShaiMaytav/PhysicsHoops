using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
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
            ball.ResetValues();
            ball.transform.position = startPos;
            Debug.Log("Ground");
            ball.enabled = false;
            coll.didCollide = false;
        }
    }
}
