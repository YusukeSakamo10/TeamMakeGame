using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    Vector3 target;
    Vector3 prevPos;

    [SerializeField] float step = 2f;

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
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        prevPos = target;
        
        target = transform.position +dir;
      
    }
    // �B �ړI�n�ֈړ�����
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
    }

}
