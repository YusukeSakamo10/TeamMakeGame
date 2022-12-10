using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opaque : MonoBehaviour
{
    //透明状態にする時にどれくらいの alpha にするか指定する
    [SerializeField] float targetAlpha = 0.6f;
    //元の状態のα
    float m_opaque = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            //当たったオブジェクトのレンダラーを取得しαを変える
            Gimmick g = other.gameObject.GetComponent<Gimmick>();
            Renderer r = other.gameObject.GetComponent<Renderer>();
            r.material = g.transMat;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            //当たったオブジェクトのレンダラーを取得しαを変える
            Gimmick g = other.gameObject.GetComponent<Gimmick>();
            Renderer r = other.gameObject.GetComponent<Renderer>();
            r.material = g.transMat;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            //当たったオブジェクトのレンダラーを取得しαを変える
            Gimmick g = other.gameObject.GetComponent<Gimmick>();
            Renderer r = other.gameObject.GetComponent<Renderer>();
            r.material = g.originalMat;
        }
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
