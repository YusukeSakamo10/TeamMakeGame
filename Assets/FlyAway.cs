using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAway : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 pos = collision.transform.position;
            pos.y = pos.y + 100;
            collision.transform.position = pos;
        }
    }
}
