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
        // ‡@ ˆÚ“®’†‚©‚Ç‚¤‚©‚Ì”»’èBˆÚ“®’†‚Å‚È‚¯‚ê‚Î“ü—Í‚ğó•t
        if (transform.position == target && _isSelected)
        {
            SetTargetPosition();
        }
        Move();
    }

    // ‡A “ü—Í‚É‰‚¶‚ÄˆÚ“®Œã‚ÌˆÊ’u‚ğZo
    void SetTargetPosition()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        target = transform.position + dir * distance;

    }

    public void Forward()
    {
        if (transform.position == target && _isSelected)
        {
            Vector3 dir = new Vector3(0, 0, 1);

            target = transform.position + dir * distance;
        }
    }
    public void Backward()
    {
        if (transform.position == target && _isSelected)
        {
            Vector3 dir = new Vector3(0, 0, -1);

            target = transform.position + dir * distance;
        }
    }
    public void Left()
    {
        if (transform.position == target && _isSelected)
        {
            Vector3 dir = new Vector3(-1, 0, 0);

            target = transform.position + dir * distance;
        }
    }
    public void Right()
    {
        if (transform.position == target && _isSelected)
        {
            Vector3 dir = new Vector3(1, 0, 0);

            target = transform.position + dir * distance;
        }
    }


    // ‡B –Ú“I’n‚ÖˆÚ“®‚·‚é
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
    }
}
