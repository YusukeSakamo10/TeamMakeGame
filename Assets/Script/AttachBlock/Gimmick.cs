using UnityEngine;

public class Gimmick : MonoBehaviour
{
    [SerializeField] Material _outLineMat;
    Material _selectedMat;
    [SerializeField] float _interval = 0.2f;
    Material _original;
    Renderer _renderer;
    float _timer;
    GameObject _gameManager;
    opaqueBlock pivot;


    bool _isSelect = false;
    public bool _isCancel = false;
    public bool IsSelect
    {
        get { return _isSelect; }
        set { _isSelect = value; }
    }

    public Material originalMat;
    public Material transMat;

    void Start()
    {
        opaqueBlock o = GameObject.Find("pivot").GetComponent<opaqueBlock>();
        if (o != null) pivot = o.GetComponent<opaqueBlock>();

        _gameManager = GameObject.Find("GameManager").GetComponent<GameObject>();
        _renderer = GetComponent<Renderer>();
        _selectedMat = _renderer.material;
    }


    void Update()
    {
        if (!_isSelect)
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;

                if (_timer < 0)
                {
                    _renderer.material = _selectedMat;
                }
            }
        }
        else ChangeSelectColor();
    }

    public void ChangeSelectColor()
    {
        if (_isSelect)
        {
            _renderer.material = _outLineMat;
            Controll();
        }
    }

    public void ChangeColor()
    {
        _renderer.material = _outLineMat;
        _timer = _interval;
    }



    //
    public void Controll()
    {
        //�������悤�ɃN���X���󂯎��B�Ƃ肠��������͏�ɏ����ׂ����́A
        CubeController cubeController = GetComponent<CubeController>();

        if (_isCancel)
        {
            //��ŏ����������ǂ��̂�������Ȃ��v���C���𓮂������߂Ɉꎞ�I�ɒT���ē�����悤�ɂ���
            PlayerMove p = GameObject.Find("player").GetComponent<PlayerMove>();
            p.IsMove = true;
            //�I�����ꂽ�̂�����
            _isSelect = false;
            //�L�����Z���������Ȃ��悤��x�����Œʂ�悤�ɉ���
            _isCancel = false;
            pivot._EndTrans = null;
            //_Up.onClick.removeEventListener(cubeController.Forward);
        }
        if (cubeController != null)
        {
            //�I�����ꂽ�Ƃ��Ɖ������ꂽ�Ƃ��ɓ�����ԂɂȂ�̂Ŏ����̏�Ԃ𑗂�
            cubeController.IsSelect = _isSelect;
        }

    }

    public void SelectCancel()
    {
        _isCancel = true;
    }
}
