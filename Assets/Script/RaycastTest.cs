using UnityEngine;
using System.Collections;

public class RaycastTest : MonoBehaviour
{
    RaycastHit hit;

    [SerializeField]
    bool isEnable = false;

    void OnDrawGizmos()
    {
        if (isEnable == false)
            return;

        var scale = transform.lossyScale.x * 0.5f;

        var isHit = Physics.Raycast(transform.position, transform.forward, out hit, 100);
        if (isHit)
        {
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
        }
        else
        {
            Gizmos.DrawRay(transform.position, transform.forward * 100);
        }
    }
}