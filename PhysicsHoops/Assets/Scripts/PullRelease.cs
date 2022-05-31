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
    [SerializeField] MyPhysics obj;

    private void Start()
    {
        obj = GetComponent<MyPhysics>();
    }


    // Update is called once per frame
    void Update()
    {
        CalShotDir();

        GetMouseDownPos();
        GetMouseReleasePos();
        release();
    }

    private void GetMouseDownPos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDownPos = Input.mousePosition;
        }
    }

    private void GetMouseReleasePos()
    {
       
       
            mouseReleasePos = Input.mousePosition;
        
    }

    void CalShotDir()
    {
        shotDir = mouseDownPos - mouseReleasePos;
        shotDir.z = shotDir.magnitude * zStrengthMultiplier;
        shotDir.x *= xStrengthMultiplier;
        shotDir.y *= yStrengthMultiplier;
    }

    void release()
    {
        if (Input.GetMouseButtonUp(0))
        {
            obj.enabled = true;
            obj.AddForce(shotDir / forceReducer);
        }
    }

}
