using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySphereCollider : MonoBehaviour
{
    public float radius = 4;
    
    
    void Update()
    {
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
