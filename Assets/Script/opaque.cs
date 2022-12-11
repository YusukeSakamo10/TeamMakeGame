using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opaque : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            //���������I�u�W�F�N�g�̃����_���[���擾������ς���
            Gimmick g = other.gameObject.GetComponent<Gimmick>();
            Renderer r = other.gameObject.GetComponent<Renderer>();
            r.material = g.transMat;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            //���������I�u�W�F�N�g�̃����_���[���擾������ς���
            Gimmick g = other.gameObject.GetComponent<Gimmick>();
            Renderer r = other.gameObject.GetComponent<Renderer>();
            r.material = g.transMat;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            //���������I�u�W�F�N�g�̃����_���[���擾������ς���
            Gimmick g = other.gameObject.GetComponent<Gimmick>();
            Renderer r = other.gameObject.GetComponent<Renderer>();
            r.material = g.originalMat;
        }
    }
}
