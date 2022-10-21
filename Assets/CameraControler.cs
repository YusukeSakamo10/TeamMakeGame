using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    GameObject mainCamera;
    GameObject normalCamera;
    GameObject pickCamera;

    GameObject XpCamera;
    GameObject XmCamera;
    GameObject YpCamera;
    GameObject YmCamera;

    GameObject cameraNow;

    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        normalCamera = GameObject.Find("NormalCamera");
        pickCamera = GameObject.Find("PickCamera");

        XpCamera = GameObject.Find("X+Camera");
        XmCamera = GameObject.Find("X-Camera");
        YpCamera = GameObject.Find("Z+Camera");
        YmCamera = GameObject.Find("Z-Camera");

        mainCamera.SetActive(true);
        normalCamera.SetActive(true);
        
        pickCamera.SetActive(false);
        XpCamera.SetActive(false);
        XmCamera.SetActive(false);
        YpCamera.SetActive(false);
        YmCamera.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            normalCamera.SetActive(false);
            pickCamera.SetActive(true);
            XpCamera.SetActive(false);
            XmCamera.SetActive(false);
            YpCamera.SetActive(false);
            YmCamera.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            pickCamera.SetActive(false);
            XpCamera.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            normalCamera.SetActive(true);
            pickCamera.SetActive(false);
            XpCamera.SetActive(false);
            XmCamera.SetActive(false);
            YpCamera.SetActive(false);
            YmCamera.SetActive(false);
        }
    }

    public void CameraChange(GameObject camera,GameObject cameraFin)
    {
        camera.SetActive(true);
        cameraFin.SetActive(false);
    }
}
