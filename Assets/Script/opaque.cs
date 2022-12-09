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
        if (other.gameObject.tag == "Block")
        {
            Debug.Log("AAAAAA");
            MeshRenderer m = other.gameObject.GetComponent<MeshRenderer>();
            m.material.SetFloat("_Mode", 2);
            //m.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            //m.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            //m.material.SetInt("_ZWrite", 0);
            //m.material.DisableKeyword("_ALPHATEST_ON");
            //m.material.EnableKeyword("_ALPHABLEND_ON");
            //m.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            //m.material.SetOverrideTag("RenderType", "Fade");
            ////���������I�u�W�F�N�g�̃����_���[���擾������ς���
            //Renderer r = other.gameObject.GetComponent<Renderer>();
            //ChangeAlpha(r, m_transparency);
        }
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
