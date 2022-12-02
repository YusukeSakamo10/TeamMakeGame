using UnityEngine;

public class Gimmick : MonoBehaviour
{
    [SerializeField] Material _focusMat;
    [SerializeField] Material _selectedMat;
    [SerializeField] float _interval = 0.5f;
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

    void Start()
    {
        opaqueBlock o = GameObject.Find("pivot").GetComponent<opaqueBlock>();
        if (o != null) pivot = o.GetComponent<opaqueBlock>();

        _gameManager = GameObject.Find("GameManager").GetComponent<GameObject>();
        _renderer = GetComponent<Renderer>();
        _original = _renderer.material;
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
                    _renderer.material = _original;
                }
            }
        }
        else
        {
            _renderer.material = _selectedMat;
            Controll();
        }
    }


    public void ChangeColor()
    {
        _renderer.material = _focusMat;
        _timer = _interval;
    }

    public void Controll()
    {
        CubeController cubeController = GetComponent<CubeController>();

        if (_isCancel)
        {
            PlayerMove p = GameObject.Find("player").GetComponent<PlayerMove>();
            p.IsMove = true;
            _isSelect = false;
            _isCancel = false;
            pivot._EndTrans = null;
            //_Up.onClick.removeEventListener(cubeController.Forward);
        }
        if (cubeController != null)
        {
            cubeController.IsSelect = _isSelect;
        }

    }

    public void SelectCancel()
    {
        _isCancel = true;
    }
}
