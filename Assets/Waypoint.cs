using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color gizmosColor = new Color(1, 0, 1);
    [SerializeField] float gizmosSize = 1f;
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;
        Gizmos.DrawSphere(transform.position, gizmosSize);
    }
}
