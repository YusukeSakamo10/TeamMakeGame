using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJAnime : MonoBehaviour
{
    /// <summary>キャラクターなどのアニメーションするオブジェクトを指定する</summary>
    [SerializeField] Animator _MJanimator = default;
    [SerializeField] Animator _Houkianimator = default;

    [SerializeField] PlayerMove _playerMove = null;


    private void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (_playerMove.IsGround && _playerMove.IsMove)
            {
                _Houkianimator.SetFloat("Walk", 1);
                _MJanimator.SetFloat("Speed", 1);
            }
        }
        else
        {
            _MJanimator.SetFloat("Speed", 0);
            _Houkianimator.SetFloat("Walk", 0);
        }

        if (!_playerMove.IsGround && _playerMove.IsMove)
        {
            _MJanimator.SetBool("Jump", true);
            _Houkianimator.SetBool("Jump", true);
        }
        else
        {
            _MJanimator.SetBool("Jump", false);
            _Houkianimator.SetBool("Jump", false);
        }

        if (!_playerMove.IsMove)
        {
            _MJanimator.SetBool("Select", true);
            _Houkianimator.SetFloat("Walk", 1);
        }
        else
        {
            _MJanimator.SetBool("Select", false);
            _Houkianimator.SetFloat("Walk",0);
        }
    }
}
