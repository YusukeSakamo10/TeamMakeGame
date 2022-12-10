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
            // �n�_�ƏI�_�̒��ԂɈړ����A�p�x�𒲐����A�R���C�_�[�̒������v�Z���Đݒ肷��
            Vector3 pivotPosition = (startPos.position + endPos.position) / 2;
            transform.position = pivotPosition;
            //���a
            Vector3 dir = endPos.position - transform.position;
            //�I�_���璆�_�܂ł̌���
            transform.forward = dir;
            //���Ă���{�b�N�X�R���C�_�[���擾
            BoxCollider col = GetComponent<BoxCollider>();
            //Distance a - b ����
            float distance = Vector3.Distance(startPos.position, endPos.position);
            
            //���X�̃{�b�N�X�R���C�_�[��XY��Z�������̋���
            col.size = new Vector3(3, 3, distance);
        }
    }
}
