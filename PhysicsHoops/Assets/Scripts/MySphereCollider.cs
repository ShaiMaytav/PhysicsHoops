using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySphereCollider : MonoBehaviour
{
    public float radius = 4;
    [HideInInspector] public Vector3 Max;
    [HideInInspector] public Vector3 Min;

    void Update()
    {
        CalBounds();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void CalBounds()
    {
        Min = new Vector3(transform.position.x - radius, transform.position.y - radius, transform.position.z - radius);
        Max = new Vector3(transform.position.x + radius, transform.position.y + radius, transform.position.z + radius);
    }
}
