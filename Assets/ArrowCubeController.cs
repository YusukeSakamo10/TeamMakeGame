using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCubeController : MonoBehaviour
{
    Vector3 target;
    //Vector3 prevPos;

    [SerializeField] float step = 2f;
    [SerializeField] float distance = 1;
    
    bool _isSelected = false;

    public bool IsSelect
    {
        get { return _isSelected; }
        set { _isSelected = value; }

    }

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // �@ 移動中かどうかの判定。移動中でなければ入力を受付
        if (transform.position == target && _isSelected)
        {
            SetTargetPosition();
        }
        Move();
    }

    // �A 入力に応じて移動後の位置を算出
    void SetTargetPosition()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        target = transform.position + dir * distance;

    }

    public void Forward()
    {
        Vector3 dir = new Vector3(0, 0, 1);

        target = transform.position + dir * distance;
    }
    public void Backward()
    {
        Vector3 dir = new Vector3(0, 0, -1);

        target = transform.position + dir * distance;
    }
    public void Left()
    {
        Vector3 dir = new Vector3(-1, 0, 0);

        target = transform.position + dir * distance;
    }
    public void Right()
    {
        Vector3 dir = new Vector3(1, 0, 0);

        target = transform.position + dir * distance;
    }


    // �B 目的地へ移動する
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
    }


}
