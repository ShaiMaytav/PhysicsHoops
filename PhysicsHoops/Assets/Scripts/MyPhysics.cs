using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPhysics : MonoBehaviour
{
    [SerializeField] Vector3 gravityForce = new Vector3 (0.0f, -9.8f, 0.0f);
    public Vector3 velocity;
    public Vector3 force;
    public float mass;
    [SerializeField] Vector3 acc;
    [SerializeField] bool useGravity;
    [SerializeField] Vector3 force2Add;
    [SerializeField][Range(0, 1)] float bounce;

    private void Start()
    {
      this.enabled = false;
    }

    private void Update()
    {
        CalVelocity();
        ApplyForce();
    }
    
    public void Bounce()
    {
        velocity = new Vector3(velocity.x, Mathf.Abs(velocity.y * bounce), velocity.z);
        acc.y = 0;
        force.y = 0;
        //AddForce(new Vector3 (0, bounce, 0));
    }

    public void ApplyForce()
    {
        CalculateForce();
        transform.position += velocity * Time.deltaTime;
    }

    private void CalVelocity()
    {
        acc = force / mass;
        velocity = velocity + acc * Time.deltaTime;
    }

    public void AddForce(Vector3 f)
    {
        velocity += f;
    }

    private Vector3 CalculateForce()
    {
        //force += force2Add;
        if (useGravity)
        {
            force += gravityForce;
        }
        return force;
    }

    public void ResetValues()
    {
        velocity = Vector3.zero;
        acc = Vector3.zero;
        force = Vector3.zero;
    }

    #region TempTrash
    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("check");
    //    isFalling = false;
    //    other.gameObject.GetComponent<Physics>().isFalling = false;

    //}
    #endregion

}
