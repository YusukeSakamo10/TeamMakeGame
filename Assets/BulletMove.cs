using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0.5f, -1.87f);
    }
    public Vector3 v = new Vector3( 0, 0, 0 );
    // Update is called once per frame
    void Update()
    {
        transform.localPosition += v;
    }
}
