using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullRelease : MonoBehaviour
{
    [SerializeField] Vector3 mouseDownPos;
    [SerializeField] Vector3 mouseReleasePos;
    [SerializeField] Vector3 shotDir;
    [SerializeField] float pullStrength;
    [SerializeField] float xStrengthMultiplier = 1;
    [SerializeField] float yStrengthMultiplier = 1;
    [SerializeField] float zStrengthMultiplier = 1;
    [SerializeField] float forceReducer = 1;  
    MyPhysics obj;

    private void Start()
    {
        obj = GetComponent<MyPhysics>();
    }


    // Update is called once per frame
    void Update()
    {
        if (obj.enabled == false)
        {
            CalShotDir();

            GetMouseDownPos();
            GetMouseReleasePos();
            release();
        }
    }

    /// <summary>
    /// Gets the position on the screen where the player clicked
    /// </summary>
    private void GetMouseDownPos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDownPos = Input.mousePosition;
        }
    }
    /// <summary>
    /// Gets the postion of the mouse on the screen 
    /// </summary>
    private void GetMouseReleasePos()
    {
            mouseReleasePos = Input.mousePosition;
    }

    /// <summary>
    /// Converts the 2D vector the player created 
    /// using the mouse into a 3D vector with 
    /// customizable multipliers
    /// </summary>
    void CalShotDir()
    {
        shotDir = mouseDownPos - mouseReleasePos;
        shotDir.z = shotDir.magnitude * zStrengthMultiplier;
        shotDir.x *= xStrengthMultiplier;
        shotDir.y *= yStrengthMultiplier;
    }

    /// <summary>
    /// Activates physics behavior of an object when mouse0 is released
    /// </summary>
    void release()
    {
        if (Input.GetMouseButtonUp(0))
        {
            obj.enabled = true;
            obj.AddForce(shotDir / forceReducer);
        }
    }
}
