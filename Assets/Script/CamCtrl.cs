using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamCtrl : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    float viewAngle;
    float inputX, inputY;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            inputX = Input.GetAxis("Mouse X");
            inputY = Input.GetAxis("Mouse Y");

            Rotate(inputX, inputY, viewAngle);
        }
    }

    //ƒJƒƒ‰‰ñ“]
    void Rotate(float inputX, float inputY, float limit)
    {
        float maxLimit = limit, minLimit = 360 - maxLimit;

        //XŽ²‰ñ“]
        var angle = transform.eulerAngles;
        angle.x -= inputY;

        //‰ñ“]§ŒÀ
        if (angle.x > maxLimit && angle.x < 180)
            angle.x = maxLimit;
        if (angle.x < minLimit && angle.x > 180)
            angle.x = minLimit;

        //YŽ²‰ñ“]
        angle.y += inputX;
        transform.eulerAngles = angle;
    }
}
