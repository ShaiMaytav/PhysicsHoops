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
    
    /// <summary>
    /// Simluate bounce
    /// </summary>
    public void Bounce()
    {
        velocity = new Vector3(velocity.x, Mathf.Abs(velocity.y * bounce), velocity.z);//adds the bounce force to the y axis 
        acc.y = 0;//resets y axis acceleration 
        force.y = 0;//resets y axis acceleration
    }

    /// <summary>
    /// applies force and moves the object according to calculations
    /// </summary>
    public void ApplyForce()
    {
        CalGravity();
        transform.position += velocity * Time.deltaTime;//changes object's position
    }

    /// <summary>
    /// Calculates the acceleration and velocity
    /// </summary>
    private void CalVelocity()
    {
        acc = force / mass;//calculates acceleration
        velocity = velocity + acc * Time.deltaTime;//updates the velocity
    }

    /// <summary>
    /// Adds a given force to the object's current force
    /// </summary>
    /// <param name="f">The given force</param>
    public void AddForce(Vector3 f)
    {
        velocity += f;
    }

    /// <summary>
    /// Calculates and applies gravity if useGravity is true
    /// </summary>
    /// <returns>Returns a new vector equals </returns>
    private Vector3 CalGravity()
    {
        if (useGravity)
        {
            force += gravityForce;
        }
        return force;
    }

    /// <summary>
    /// Resets an object's velocity, acceleration and force
    /// </summary>
    public void ResetValues()
    {
        velocity = Vector3.zero;
        acc = Vector3.zero;
        force = Vector3.zero;
    }
}
