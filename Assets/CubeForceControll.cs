using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeForceControll : MonoBehaviour
{
    Vector3 target = Vector3.zero;
    Rigidbody _rb;

    [SerializeField] float distance = 2;

    [SerializeField] bool _isSelected = false;

    public bool IsSelect
    {
        get { return _isSelected; }
        set { _isSelected = value; }
    }

    int timer = 2000;

    bool forwardFlag = false;
    bool rightFlag = false;
    bool leftFlag = false;
    bool backFlag = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (forwardFlag)
        {
            timer--;
            if (timer > 0)
            {
                _rb.AddForce(transform.forward);
            }
        }
        else if (backFlag)
        {
            timer--;
            if (timer > 0)
            {
                _rb.AddForce(-transform.forward);
            }
        }
        else if (leftFlag)
        {
            timer--;
            if (timer > 0)
            {
                _rb.AddForce(-transform.right);
            }
        }
        else if (rightFlag)
        {
            timer--;
            if (timer > 0)
            {
                _rb.AddForce(transform.right);
            }
        }

        if (timer < 0)
        {
            Reset();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Reset();
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
        forwardFlag = true;
    }
    public void Backward()
    {
        backFlag = true;
    }
    public void Left()
    {
        leftFlag = true;
    }
    public void Right()
    {
        rightFlag = true;
    }

    private void Reset()
    {
        forwardFlag = false;
        rightFlag = false;
        backFlag = false;
        leftFlag = false;
        timer = 0;
        _rb.velocity = Vector3.zero;
    }
}
