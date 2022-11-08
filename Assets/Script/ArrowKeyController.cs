using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){

            this.transform.rotation = new Quaternion(0, 0, Camera.main.transform.rotation.y, 0);
        } 
    }
}
