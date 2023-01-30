using UnityEngine;

public class CubeController : MonoBehaviour
{
    GameManager _GameManager;

    Vector3 target;
    //�O�̈ʒu��ۑ�
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
        //���������̂�e�Ƃ��Đ�s�œ����蔻��p�̎q��ۑ����邽�߂�
        _children = new Transform[this.transform.childCount];
        _childrenCollider = new PostCollider[this.transform.childCount];
        int count = 0;
        //�q�I�u�W�F�N�g��o�^���Ă���
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
        //�q�I�u�W�F�N�g���ЂƂ܂��I�t�ɓo�^
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
            //�ړ��񐔂��L�^���đO�̈ʒu���X�V�̃^�C�~���O���m�F
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
            //�ړ��񐔂��L�^���đO�̈ʒu���X�V�̃^�C�~���O���m�F
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
            //�ړ��񐔂��L�^���đO�̈ʒu���X�V�̃^�C�~���O���m�F
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
            //�ړ��񐔂��L�^���đO�̈ʒu���X�V�̃^�C�~���O���m�F
            //_resetPrePos += 1;
        }
    }

    // �B �ړI�n�ֈړ�����
    void Move()
    {
        if (target != Vector3.zero)
        {
            //�������O�̏�Ԃ�ۑ����Ė߂������𔻒f

            if (_resetPrePos == 2)
            {
                if (_prePos != target)
                {
                    //�����O�Ɉʒu��ς���
                    _prePos = transform.position;
                }
                else if (_prePos == target)
                {
                    //���Ō��̈ʒu�����A�`�悷��̂Ƀ^�C�~���O���������Ƃ��Ȃ̂ŁA���Z�����݂�-3
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
        //�e�N���X���I������Ă��邩���f���Ďq�I�u�W�F�N�g�ɑ΂��ăA�N�V����
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
    /// �I�����ꂽ�I�u�W�F�N�g���O�Ɠ��������f
    /// </summary>
    /// <param name="isSame"></param>
    public void Back(bool isSame)
    {

        if (isSame) return;
        _prePos = transform.position;
    }
}
