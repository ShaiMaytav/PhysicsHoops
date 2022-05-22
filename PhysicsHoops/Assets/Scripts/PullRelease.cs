using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullRelease : MonoBehaviour
{
    [SerializeField] Vector3 mouseDownPos;
    [SerializeField] Vector3 mouseReleasePos;
    [SerializeField] Vector3 shotDir;
    [SerializeField] float pullStrength;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        CalShotDir();

        GetMouseDownPos();
        GetMouseReleasePos();
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
        if (Input.GetMouseButtonUp(0))
        {
            mouseReleasePos = Input.mousePosition;
        }
    }

    void CalShotDir()
    {
        shotDir = mouseDownPos - mouseReleasePos;
        shotDir.z = shotDir.magnitude;
    }

}
