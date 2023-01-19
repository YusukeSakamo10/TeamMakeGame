using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float _power = 8;
    public Rigidbody _rb;
    float h;
    float v;
    public float _jumpPower = 10;
    [SerializeField] LayerMask _layerMask;
    public float groundFlow = 3.3f;

    [SerializeField] bool _isMove = true;
    [SerializeField] bool _isGround = true;

    public bool IsGround
    {
        get { return _isGround; }
        set { _isGround = value; }
    }

    public bool IsMove
    {
        get { return _isMove; }
        set { _isMove = value; }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        _power = 8;

        if (_isMove)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
        }
        else { h = 0; v = 0;}

        Vector3 rayPosition = new(transform.position.x, transform.position.y + 3, transform.position.z);

        Ray ray = new Ray(rayPosition, new Vector3(0, -1, 0));
        RaycastHit hit;

        Debug.DrawRay(rayPosition, ray.direction * groundFlow, Color.green);
     
        if (Physics.Raycast(ray,out hit, groundFlow, _layerMask))
        {
            _isGround = true;
        }
        else { _isGround = false; }

        if(_isGround && _isMove)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
               _rb.AddForce(Vector3.up * _jumpPower,ForceMode.Impulse);
            }
        }
        else 
        {
            _power = 6;
        }

        _rb.AddForce((Vector3.forward * v + Vector3.right * h).normalized * _power);

        //�L�[��������Ă��Ȃ��Ƃ��J�����̕���������
        //if (h == 0 && v == 0 && y == 0)
        //{
        //    Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        //    transform.rotation = Quaternion.LookRotation(cameraForward);
        //}
    }

    void FixedUpdate()
    {
        // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
        // �J�����̌����Ă�������@�@�@//Scale 2�̃x�N�g���̊e��������Z
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 moveForward = cameraForward * v + Camera.main.transform.right * h;

        // �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
        _rb.velocity = Vector3.Normalize(moveForward) * _power + new Vector3(0, _rb.velocity.y, 0);

        // �L�����N�^�[�̌�����i�s������
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }
}