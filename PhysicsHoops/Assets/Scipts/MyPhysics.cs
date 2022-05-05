using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPhysics : MonoBehaviour
{
    public Vector3 gravityForce = new Vector3 (0.0f, -9.8f, 0.0f);
    public Vector3 velocity;
    public Vector3 force;
    public float mass;
    public bool useGravity;
    [SerializeField]private Vector3 force2Add;

    private void Start()
    {
      
    }

    private void Update()
    {
        CalVelocity();
        ApplyForce();
        //force2Add += gravityForce;
        //if (force2Add.y <= 0)
        //{
        //    force2Add.y = 0;
        //}
        if (Input.anyKeyDown)
        {
            AddForce(new Vector3 (0, 100f, 0));
        }
    }
    

    public void ApplyForce()
    {
        CalculateForce();
        transform.position += velocity * Time.deltaTime;
    }

    private void CalVelocity()
    {
        Vector3 acc = force / mass;
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
    
    

    #region Trash
    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("check");
    //    isFalling = false;
    //    other.gameObject.GetComponent<Physics>().isFalling = false;

    //}
    #endregion

}
