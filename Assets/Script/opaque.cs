using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opaque : MonoBehaviour
{
    //透明状態にする時にどれくらいの alpha にするか指定する
    [SerializeField] float m_transparency = 0.2f;
    //元の状態のα
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
            ////当たったオブジェクトのレンダラーを取得しαを変える
            //Renderer r = other.gameObject.GetComponent<Renderer>();
            //ChangeAlpha(r, m_transparency);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //当たらなくなったオブジェクトのレンダラーを取得しαを元に戻す
        Renderer r = other.gameObject.GetComponent<Renderer>();
        ChangeAlpha(r, m_opaque);
    }

    // alphaを変更する関数
    void ChangeAlpha(Renderer renderer, float targetAlpha)
    {
        if (renderer)
        {
            Material m = renderer.material;
            Color c = m.color;
            //αを書き換えてマテリアルに戻す
            c.a = targetAlpha;
            m.color = c;
        }
    }
}
