using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rim : MonoBehaviour
{
    MyBoxCollider coll;
    MyPhysics ball;
    void Start()
    {
        coll = GetComponent<MyBoxCollider>();
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<MyPhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coll.didCollide)
        {
            ball.Bounce();
            coll.didCollide = false;
        }
    }
}
