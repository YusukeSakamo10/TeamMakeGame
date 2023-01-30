using UnityEngine;

public class CubeController : MonoBehaviour
{
    GameManager _GameManager;

    Vector3 target;
    //前の位置を保存
    Vector3 _prePos;
    [SerializeField] float step = 4f;
    [SerializeField] float distance = 4;

    [SerializeField] bool _isSelected = false;

    Transform[] _children;
    PostCollider[] _childrenCollider;
    public bool IsSelect
    {
        get { return _isSelected; }
        set { _isSelected = value; }
    }
    private int _resetPrePos = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameManager g = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (g != null) _GameManager = g.GetComponent<GameManager>();

        target = transform.position;
        _prePos = transform.position;
        //動かすものを親として先行で当たり判定用の子を保存するために
        _children = new Transform[this.transform.childCount];
        _childrenCollider = new PostCollider[this.transform.childCount];
        int count = 0;
        //子オブジェクトを登録していく
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
        //子オブジェクトをひとまずオフに登録
        SetPosChildBox();
    }
    private void FixedUpdate()
    {
        if (target != transform.position) Move();
    }

    public void Forward()
    {
        if (transform.position == target && _isSelected)
        {
            if (invalid()) return;

            Vector3 dir = new Vector3(0, 0, 1);

            target = transform.position + dir * distance;
            _GameManager.MoveCount();
            //移動回数を記録して前の位置を更新のタイミングを確認
            //_resetPrePos += 1;

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
            //移動回数を記録して前の位置を更新のタイミングを確認
            //_resetPrePos += 1;
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
            //移動回数を記録して前の位置を更新のタイミングを確認
            //_resetPrePos += 1;
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
            //移動回数を記録して前の位置を更新のタイミングを確認
            //_resetPrePos += 1;
        }
    }

    // ③ 目的地へ移動する
    void Move()
    {
        if (target != Vector3.zero)
        {
            //動かす前の状態を保存して戻したかを判断

            if (_resetPrePos == 2)
            {
                if (_prePos != target)
                {
                    //動く前に位置を変える
                    _prePos = transform.position;
                }
                else if (_prePos == target)
                {
                    //二回で元の位置だが、描画するのにタイミングが押したときなので、加算も混みで-3
                    _GameManager.MoveCountValue = _GameManager.MoveCountValue - 3;
                    _GameManager.MoveCount();
                }
                _resetPrePos = 1;

            }

            transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
            if (_prePos == transform.position)
            {
                _prePos = transform.position;
            }
        }
    }

    public void SetPosChildBox()
    {
        //親クラスが選択されているか判断して子オブジェクトに対してアクション
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
        if (_GameManager.MoveCountValue >= _GameManager.MaxMoveCount) { return true; }
        return false;
    }

    /// <summary>
    /// 選択されたオブジェクトが前と同じか判断
    /// </summary>
    /// <param name="isSame"></param>
    public void Back(bool isSame)
    {

        if (isSame) return;
        _prePos = transform.position;
    }
}
