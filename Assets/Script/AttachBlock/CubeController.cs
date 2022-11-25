using UnityEngine;

public class CubeController : MonoBehaviour
{
    GameManager _GameManager;

    Vector3 target;

    [SerializeField] float step = 4f;
    [SerializeField] float distance = 4;

    [SerializeField] bool _isSelected = false;
    // [SerializeField] bool _isMovedd = false;
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
        GameManager g = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (g != null) _GameManager = g.GetComponent<GameManager>();

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
        Move();
    }

    public void Forward()
    {
        if (transform.position == target && _isSelected)
        {
            if (invalid()) return;

            Vector3 dir = new Vector3(0, 0, 1);

            target = transform.position + dir * distance;

            _GameManager.MoveCount();
        }
    }
    public void Backward()
    {
        if (transform.position == target && _isSelected)
        {
            if (invalid()) return;

            Vector3 dir = new Vector3(0, 0, -1);

            target = transform.position + dir * distance;
            _GameManager.MoveCount();
        }
    }
    public void Left()
    {
        if (transform.position == target && _isSelected)
        {
            if (invalid()) return;

            Vector3 dir = new Vector3(-1, 0, 0);

            target = transform.position + dir * distance;
            _GameManager.MoveCount();
        }
    }
    public void Right()
    {
        if (transform.position == target && _isSelected)
        {
            if (invalid()) return;

            Vector3 dir = new Vector3(1, 0, 0);

            target = transform.position + dir * distance;
            _GameManager.MoveCount();
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

    private bool invalid()
    {
        if(_GameManager.MoveCountValue >= _GameManager.MaxMoveCount) { return true; }
        return false;
    }

}
