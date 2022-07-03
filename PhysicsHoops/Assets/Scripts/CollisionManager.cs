using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] MySphereCollider ball;
    [SerializeField] MyBoxCollider hoop;
    
    public bool CheckCol()
    {
        // get box closest point to sphere center by clamping
        var x = Mathf.Max(hoop.xMin, Mathf.Min(ball.transform.position.x, hoop.xMax));
        var y = Mathf.Max(hoop.yMin, Mathf.Min(ball.transform.position.y, hoop.yMax));
        var z = Mathf.Max(hoop.zMin, Mathf.Min(ball.transform.position.z, hoop.zMax));

        // this is the same as isPointInsideSphere
        var distance = Mathf.Sqrt((x - ball.transform.position.x) * (x - ball.transform.position.x) +
                                 (y - ball.transform.position.y) * (y - ball.transform.position.y) +
                                 (z - ball.transform.position.z) * (z - ball.transform.position.z));

        return distance < ball.radius;
    }
}
