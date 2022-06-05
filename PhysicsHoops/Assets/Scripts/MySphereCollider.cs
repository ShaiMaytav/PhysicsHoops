using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySphereCollider : MonoBehaviour
{
    public float radius = 4;
    public Vector3 center;
    
    
    void Update()
    {
        center = transform.position;
    }

    private void OnDrawGizmosSelected()
    {
        center = transform.position;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(center, radius);
    }
}
