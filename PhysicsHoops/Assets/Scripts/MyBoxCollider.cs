using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBoxCollider : MonoBehaviour
{
    public float height;
    public float width;
    public float depth;

    //bounds
    [HideInInspector] public float xMax;
    [HideInInspector] public float xMin;
    [HideInInspector] public float yMax;
    [HideInInspector] public float yMin;
    [HideInInspector] public float zMax;
    [HideInInspector] public float zMin;

    private void Update()
    {
        CalBounds();
    }

    private void OnDrawGizmosSelected()
    {
        CalBounds();
        DrawBox();
    }

    /// <summary>
    /// Draw lines to form a wire box in the scene
    /// </summary>
    private void DrawBox()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(xMax, yMax, zMax), new Vector3(xMin, yMax, zMax));
        Gizmos.DrawLine(new Vector3(xMax, yMax, zMax), new Vector3(xMax, yMin, zMax));
        Gizmos.DrawLine(new Vector3(xMax, yMax, zMax), new Vector3(xMax, yMax, zMin));
        Gizmos.DrawLine(new Vector3(xMin, yMin, zMin), new Vector3(xMax, yMin, zMin));
        Gizmos.DrawLine(new Vector3(xMin, yMin, zMin), new Vector3(xMin, yMax, zMin));
        Gizmos.DrawLine(new Vector3(xMin, yMin, zMin), new Vector3(xMin, yMin, zMax));
        Gizmos.DrawLine(new Vector3(xMax, yMax, zMin), new Vector3(xMin, yMax, zMin));
        Gizmos.DrawLine(new Vector3(xMax, yMax, zMin), new Vector3(xMax, yMin, zMin));
        Gizmos.DrawLine(new Vector3(xMin, yMin, zMax), new Vector3(xMin, yMax, zMax));
        Gizmos.DrawLine(new Vector3(xMin, yMin, zMax), new Vector3(xMax, yMin, zMax));
        Gizmos.DrawLine(new Vector3(xMax, yMin, zMin), new Vector3(xMax, yMin, zMax));
        Gizmos.DrawLine(new Vector3(xMin, yMax, zMin), new Vector3(xMin, yMax, zMax));

    }

    /// <summary>
    /// Calculaes all bound points of the collider
    /// </summary>
    void CalBounds()
    {
        xMax = transform.position.x + width;
        xMin = transform.position.x - width;

        yMax = transform.position.y + height;
        yMin = transform.position.y - height;

        zMax = transform.position.z + depth;
        zMin = transform.position.z - depth;
    }
}
