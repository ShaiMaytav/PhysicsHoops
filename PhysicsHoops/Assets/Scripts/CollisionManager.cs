using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] MySphereCollider ball;
    [SerializeField] MyBoxCollider[] boxes;

    private void FixedUpdate()
    {
        CheckCol();
    }

    public void CheckCol()
    {
        foreach (var box in boxes)
        {
            // get box closest point to sphere center by clamping
            var x = Mathf.Max(box.xMin, Mathf.Min(ball.transform.position.x, box.xMax));
            var y = Mathf.Max(box.yMin, Mathf.Min(ball.transform.position.y, box.yMax));
            var z = Mathf.Max(box.zMin, Mathf.Min(ball.transform.position.z, box.zMax));

            // this is the same as isPointInsideSphere
            var distance = Mathf.Sqrt((x - ball.transform.position.x) * (x - ball.transform.position.x) +
                                     (y - ball.transform.position.y) * (y - ball.transform.position.y) +
                                     (z - ball.transform.position.z) * (z - ball.transform.position.z));

            if (distance < ball.radius)
            {
                box.didCollide = true;
                Debug.Log("Coll");
            }
        }
    }
}
