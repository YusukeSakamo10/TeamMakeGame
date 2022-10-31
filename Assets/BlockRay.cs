using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRay : MonoBehaviour
{
    [SerializeField] float RayLange = 1;

    void Update()
    {
        Vector3 rayPosition = new(transform.position.x, transform.position.y, transform.position.z);

        Debug.DrawRay(rayPosition, transform.right * RayLange, Color.red);
        Debug.DrawRay(rayPosition, -transform.right * RayLange, Color.red);
        Debug.DrawRay(rayPosition, transform.forward * RayLange, Color.red);
        Debug.DrawRay(rayPosition, -transform.forward * RayLange, Color.red);

    }
}
