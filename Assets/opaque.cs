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
        //当たったオブジェクトのレンダラーを取得しαを変える
        Renderer r = other.gameObject.GetComponent<Renderer>();
        ChangeAlpha(r, m_transparency);
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
