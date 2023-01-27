using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaidanFade : MonoBehaviour
{
    [SerializeField] GameObject kaidan;
    [SerializeField] MeshRenderer[] kaidanMesh;

    private void OnTriggerEnter(Collider other)
    {
        kaidan.SetActive(true);

        int time = 0;
        time++;

        if(time%2 == 0)
        {
            kaidanMesh[0].material.color = kaidanMesh[0].material.color + new Color32(0, 0, 0, 1);
            kaidanMesh[1].material.color = kaidanMesh[1].material.color + new Color32(0, 0, 0, 1);
            kaidanMesh[2].material.color = kaidanMesh[2].material.color + new Color32(0, 0, 0, 1);
            kaidanMesh[3].material.color = kaidanMesh[3].material.color + new Color32(0, 0, 0, 1);
        }


    }
}
