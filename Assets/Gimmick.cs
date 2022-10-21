using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    [SerializeField] Material _focusMat;
    [SerializeField] float _interval = 2f;
    Material _original;
    Renderer _renderer;
    float _timer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _original = _renderer.material;
    }


    void Update()
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


    public void ChangeColor()
    {
        _renderer.material = _focusMat;
        _timer = _interval;
    }

    public void Controll()
    {


    }
}
