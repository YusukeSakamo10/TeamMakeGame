using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRay : MonoBehaviour
{
    void Update()
    {
        Vector3 rayPosition = new(transform.position.x, transform.position.y, transform.position.z);
        

        Debug.DrawRay(rayPosition, transform.right, Color.red);
        Debug.DrawRay(rayPosition, -transform.right, Color.red);
        Debug.DrawRay(rayPosition, transform.forward, Color.red);
        Debug.DrawRay(rayPosition, -transform.forward, Color.red);

    }
}
