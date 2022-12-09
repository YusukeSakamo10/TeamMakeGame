using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opaque : MonoBehaviour
{
    //������Ԃɂ��鎞�ɂǂꂭ�炢�� alpha �ɂ��邩�w�肷��
    [SerializeField] float m_transparency = 0.2f;
    //���̏�Ԃ̃�
    float m_opaque = 1f;

    private void OnTriggerEnter(Collider other)
    {
        //���������I�u�W�F�N�g�̃����_���[���擾������ς���
        Renderer r = other.gameObject.GetComponent<Renderer>();
        ChangeAlpha(r, m_transparency);
    }

    private void OnTriggerExit(Collider other)
    {
        //������Ȃ��Ȃ����I�u�W�F�N�g�̃����_���[���擾���������ɖ߂�
        Renderer r = other.gameObject.GetComponent<Renderer>();
        ChangeAlpha(r, m_opaque);
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
