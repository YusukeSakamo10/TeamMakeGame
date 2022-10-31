using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    [SerializeField] Material _focusMat;
    [SerializeField] Material _selectedMat;
    [SerializeField] float _interval = 0.5f;
    Material _original;
    Renderer _renderer;
    float _timer;

    bool _isSelect = false;
    bool _isCancel = false;
    public bool IsSelect
    {
        get { return _isSelect; }
        set { _isSelect = value; }
    }

    void Start()
    {
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
        if (_isCancel)
        {
            _isSelect = false;
            _isCancel = false;
        }
        CubeController cubeController = GetComponent<CubeController>();
        if(cubeController != null)
        {
            cubeController.IsSelect = _isSelect;
        }
        
    }

    public void SelectCancel()
    {
        _isCancel = true;
    }
}
