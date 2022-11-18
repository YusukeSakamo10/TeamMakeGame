using UnityEngine;

public class CubeController : MonoBehaviour
{
    Vector3 target;

    [SerializeField] float step = 2f;
    [SerializeField] float distance = 2;

    [SerializeField] bool _isSelected = false;
    // [SerializeField] bool _isMoved = false;
    Vector3 _switchBox;
    Transform[] _children;
    PostCollider[] _childrenCollider;
    public bool IsSelect
    {
        get { return _isSelected; }
        set { _isSelected = value; }

    }

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
        _children = new Transform[this.transform.childCount];
        _childrenCollider = new PostCollider[this.transform.childCount];
        int count = 0;
        foreach (Transform _child in this.transform)
        {
            _children[count] = _child;

            PostCollider p = _children[count].gameObject.GetComponent<PostCollider>();
            if (p)
            {
                _childrenCollider[count] = p;
            }
            count++;
        }
        SetPosChildBox();
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

    public void SetPosChildBox()
    {
        for (int i = 0; i < _children.Length; i++)
        {
            if (!_isSelected)
            {
                _children[i].transform.localScale = Vector3.zero;
                _childrenCollider[i]._isSelect = false;
            }
            else
            {
                _children[i].transform.localScale = Vector3.one;
                _childrenCollider[i]._isSelect = true;
            }

        }
    }
}
