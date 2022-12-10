using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opaque : MonoBehaviour
{
    //������Ԃɂ��鎞�ɂǂꂭ�炢�� alpha �ɂ��邩�w�肷��
    [SerializeField] float targetAlpha = 0.6f;
    //���̏�Ԃ̃�
    float m_opaque = 1f;

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

    // alpha��ύX����֐�
    void ChangeAlpha(Renderer renderer, float targetAlpha)
    {
        if (renderer)
        {
            Material m = renderer.material;
            Color c = m.color;
            //�������������ă}�e���A���ɖ߂�
            c.a = targetAlpha;
            m.color = c;
        }
    }
}
