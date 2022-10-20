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
        // ① 移動中かどうかの判定。移動中でなければ入力を受付
        if (transform.position == target)
        {
            SetTargetPosition();
        }
        Move();
    }

    // ② 入力に応じて移動後の位置を算出
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
    // ③ 目的地へ移動する
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
    }

}
