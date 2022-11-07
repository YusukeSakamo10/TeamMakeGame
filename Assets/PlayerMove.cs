using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float _power = 10;
    Rigidbody _rb;
    float h;
    float v;
    float y;
    public float _jumpPower = 10;
    [SerializeField] LayerMask _layerMask;
    public float groundFlow = 3.3f;

    bool _isMove = true;

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
        if (_isMove)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
            y = Input.GetAxisRaw("Jump");
        }
        else { h = 0; v = 0; y = 0; }

        Vector3 rayPosition = new(transform.position.x, transform.position.y + 3, transform.position.z);

        Ray ray = new Ray(rayPosition, new Vector3(0, -1, 0));
        RaycastHit hit;

        Debug.DrawRay(rayPosition, ray.direction * groundFlow, Color.green);
     
        if (Physics.Raycast(ray,out hit, groundFlow, _layerMask))
        {
            _rb.AddForce((Vector3.up * y).normalized * _jumpPower);
        }

        _rb.AddForce((Vector3.forward * v + Vector3.right * h).normalized * _power);

        //キーが押されていないときカメラの方向を向く
        if (h == 0 && v == 0 && y == 0)
        {
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

            transform.rotation = Quaternion.LookRotation(cameraForward);
        }
    }

    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        // カメラの向いている方向　　　//Scale 2つのベクトルの各成分を乗算
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * v + Camera.main.transform.right * h;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        _rb.velocity = Vector3.Normalize(moveForward) * _power + new Vector3(0, _rb.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }
}