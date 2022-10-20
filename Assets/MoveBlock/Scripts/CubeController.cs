using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    Vector3 MoveX = new Vector3(1, 0, 0);
    Vector3 MoveY = new Vector3(0, 1, 0);

    Vector3 target;
    Vector3 prevPos;

    float step = 2f;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // �@ �ړ������ǂ����̔���B�ړ����łȂ���Γ��͂���t
        if (transform.position == target)
        {
            SetTargetPosition();
        }
        Move();
    }

    // �A ���͂ɉ����Ĉړ���̈ʒu���Z�o
    void SetTargetPosition()
    {

        prevPos = target;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            target = transform.position + MoveX;

            return;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            target = transform.position - MoveX;

            return;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            target = transform.position + MoveY;

            return;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            target = transform.position - MoveY;

            return;
        }
    }
    // �B �ړI�n�ֈړ�����
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
    }

}
