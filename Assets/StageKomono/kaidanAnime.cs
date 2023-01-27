using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaidanAnime : MonoBehaviour
{
    [SerializeField] GameObject[] kaidan;
    [SerializeField] Vector3[] target;
    [SerializeField] float step = 4f;
    [SerializeField] Vector3[] StartPos = { new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0) };
    [SerializeField] bool hitFlag = false;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            StartPos[i] = kaidan[i].transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        hitFlag = true;
    }

    private void OnTriggerExit(Collider other)
    {
        hitFlag = false;
    }

    private void Update()
    {
        if (hitFlag == true)
        {
            for (int i = 0; i < 3; i++)
            {
                kaidan[i].transform.position = Vector3.MoveTowards(kaidan[i].transform.position, target[i], step * Time.deltaTime);
            }
        }

        if (hitFlag == false)
        {
            for (int i = 0; i < 3; i++)
            {
                kaidan[i].transform.position = Vector3.MoveTowards(kaidan[i].transform.position, StartPos[i], step * Time.deltaTime);
            }
        }
    }
}
