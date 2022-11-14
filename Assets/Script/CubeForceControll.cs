using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeForceControll : MonoBehaviour
{
    Vector3 target = Vector3.zero;
    Rigidbody _rb;
    Vector3 dir = new Vector3(0, 0, 0);
    [SerializeField] bool _isMove = false;
    public float MaxTime = 60;
    Vector3 prePos = Vector3.zero;
    [SerializeField] float distance = 2.4f;

    [SerializeField] bool _isSelected = false;
    public bool IsSelect
    {
        get { return _isSelected; }
        set
        {
            _isSelected = value;
            if (_rb) _rb.isKinematic = !_isSelected;
        }
    }

    float _timer = 0;

    int _direction = -1;
    enum Direction
    {
        FORWARD, RIGHT, LEFT, BACKWARD, END = -1
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb) _rb.isKinematic = true;
    }

    Vector3 vec;

    void Update()
    {
        if (_isMove)
        {
            _timer++;

            /*Vector3.Lerp(Vector3.zero, vec, 1);*//*LerpV3(Vector3.zero, vec, (_timer / MaxTime)); */
            if (_timer > MaxTime)
            {
                _timer = 0;
                _isMove = false;
                _rb.velocity = new Vector3(0, 0, 0);
                dir = new Vector3(0, 0, 0);
            }
            else { _rb.velocity = vec; }
        }

        if (_timer < 0)
        {
            Reset();
        }
        if (!_isSelected)
        {
            _isMove = false;
            _rb.velocity = new Vector3(0, 0, 0);

        }
        else
        {
            Debug.Log("time" + _timer);
        }
    }

    // ‡A “ü—Í‚É‰ž‚¶‚ÄˆÚ“®Œã‚ÌˆÊ’u‚ðŽZo
    void SetTargetPosition()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        target = transform.position + dir * distance;
    }

    private void OnTriggerEnter(Collider other)
    {
        Reset();
    }

    public void Forward()
    {
        _direction = (int)Direction.FORWARD;
        
        if (_isMove) return;
        _isMove = true;
        //dir.z = distance;
        vec.z = distance;
        vec.x = 0;vec.y = 0;
        //prePos = transform.position;
    }
    public void Backward()
    {
        _direction = (int)Direction.BACKWARD;
        
        if (_isMove) return;
        //dir.z = -distance;
        _isMove = true;
        vec.z = -distance;
        vec.x = 0; vec.y = 0;
        //prePos = transform.position;
    }
    public void Left()
    {
        _direction = (int)Direction.LEFT;
        if (_isMove) return;
        //dir.x = -distance;
        _isMove = true;
        vec.x = -distance;
        vec.z = 0; vec.y = 0;
        //prePos = transform.position;
    }
    public void Right()
    {
        _direction = (int)Direction.RIGHT;
        if (_isMove) return;
        //dir.x = distance;
        _isMove = true;
        vec.x = distance;
        vec.z = 0; vec.y = 0;
        //prePos = transform.position;
    }



    private void Reset()
    {
        _direction = (int)Direction.END;
        _timer = 0;
        _rb.velocity = Vector3.zero;
        vec.x = 0;
        vec.z = 0; vec.y = 0;
    }
}
