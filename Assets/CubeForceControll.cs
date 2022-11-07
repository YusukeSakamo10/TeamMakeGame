using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeForceControll : MonoBehaviour
{
    Vector3 target = Vector3.zero;
    Rigidbody _rb;
    Vector3 dir = new Vector3(0, 0, 0);
    bool _isMove = false;
    public float MaxTime = 60;
    Vector3 prePos = Vector3.zero;
    [SerializeField] float distance = 2;

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

    void Update()
    {

        if (_isMove)
        {
            _timer++;
         _rb.velocity = LerpV3(prePos, prePos + dir, (_timer / MaxTime)); 
            if(_timer > MaxTime)
            {
                _timer = 0;
                _isMove = false;
                _rb.velocity = new Vector3(0, 0, 0);
                dir = new Vector3(0, 0, 0);
            }
        }
        /*
                switch (_direction)
                {
                    case (int)Direction.FORWARD:

                        _rb.velocity(transform.forward);

                        break;
                    case (int)Direction.LEFT:
                        _rb.velocity(-transform.right);
                        break;

                    case (int)Direction.RIGHT:
                        //_rb.velocity(transform.right);
                        _rb.velocity = new Vector3(1,0,0);
                        break;
                    case (int)Direction.BACKWARD:
                        _rb.velocity(-transform.forward);

                        break;
                    default:

                        break;
                }
        */
        if (_timer < 0)
        {
            Reset();
        }
        if (!_isSelected)
        {
            _isMove = false;
            _rb.velocity = new Vector3(0, 0, 0);

        }

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
        dir.z = distance;
        prePos = transform.position;
    }
    public void Backward()
    {
        _direction = (int)Direction.BACKWARD;
        
        if (_isMove) return;
        dir.z = -distance;
        _isMove = true;
        prePos = transform.position;
    }
    public void Left()
    {
        _direction = (int)Direction.LEFT;
        if (_isMove) return;
        dir.x = -distance;
        _isMove = true;
        prePos = transform.position;
    }
    public void Right()
    {
        _direction = (int)Direction.RIGHT;
        if (_isMove) return;
        dir.x = distance;
        _isMove = true;
        prePos = transform.position;
    }



    private void Reset()
    {
        _direction = (int)Direction.END;
        _timer = 0;
        _rb.velocity = Vector3.zero;
    }

    private Vector3 LerpV3(Vector3 start, Vector3 end, float t)
    {
        Vector3 v;
        v.x = (1 - t) * start.x + t * end.x;
        v.y = (1 - t) * start.y + t * end.y;
        v.z = (1 - t) * start.z + t * end.z;
        return v;
    }
}
