using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjMagic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    Vector3 _camera2Mouse;

    // Update is called once per frame
    void Update()
    {
    }


    private Vector3 MouseRay2Object()
    {

        Camera.main.transform.position = _camera2Mouse;
        Ray _ray;
        _ray.origin = Camera.main.transform.position;
    
        return new Vector3();
    }
}
