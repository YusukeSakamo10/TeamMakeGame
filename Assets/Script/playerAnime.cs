using UnityEngine;

public class playerAnime : MonoBehaviour
{
    /// <summary>キャラクターなどのアニメーションするオブジェクトを指定する</summary>
    [SerializeField] Animator _animator = default;
    [SerializeField] PlayerMove _playerMove = null;


    private void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            _animator.SetFloat("Speed", 1);
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }
    }
}
