using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opaqueBlock : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;

    ObjectCameraController cinemaChine;

    public Transform _EndTrans
    {
        get { return endPos; }
        set { endPos = value; }
    }

    BoxCollider box;

    private void Start()
    {
        cinemaChine = GameObject.Find("ObjectCAM").GetComponent<ObjectCameraController>();
        box = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (cinemaChine.SelectObj == null)
        {
            box.size = new Vector3(0, 0, 0);
        }
        if (startPos && endPos)
        {
            // 始点と終点の中間に移動し、角度を調整し、コライダーの長さを計算して設定する
            Vector3 pivotPosition = (startPos.position + endPos.position) / 2;
            transform.position = pivotPosition;
            //半径
            Vector3 dir = endPos.position - transform.position;
            //終点から中点までの向き
            transform.forward = dir;
            //ついているボックスコライダーを取得
            BoxCollider col = GetComponent<BoxCollider>();
            //Distance a - b 距離
            float distance = Vector3.Distance(startPos.position, endPos.position);
            
            //元々のボックスコライダーのXYとZ軸方向の距離
            col.size = new Vector3(3, 3, distance);
        }
    }
}
