using UnityEngine;
using System.Collections;

public class SpherCastTest : MonoBehaviour
{

    RaycastHit hit;

    [SerializeField]
    bool isEnable = false;

    void OnDrawGizmos()
    {
        if (isEnable == false)
            return;

        var radius = transform.lossyScale.x * 0.5f;

        var isHit = Physics.SphereCast(transform.position, radius, transform.forward * 10, out hit);
        if (isHit)
        {
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            Gizmos.DrawWireSphere(transform.position + transform.forward * (hit.distance), radius);
        }
        else
        {
            Gizmos.DrawRay(transform.position, transform.forward * 100);
        }
    }
}