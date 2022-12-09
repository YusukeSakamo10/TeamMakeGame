using UnityEngine;
using UnityEngine.UI;


public class PostCollider : MonoBehaviour
{
    private bool _isHit = false;
    [SerializeField] Button _button;
    public bool _isSelect;
    public bool _isMoved;
    /// <summary>
    /// ���{�^���ʒu��ۑ�����悤
    /// </summary>
    private Vector3 _prePos;
    
    Vector3 _colliderPrePos;

    private void Start()
    {
        //���̈ʒu���J�n���ɕۑ�
        _colliderPrePos = this.transform.position;
        //�{�^���̊��蓖�Ă��X�N���v�g����
        SetBotton();
        //�{�^���������Ă�Ό��̈ʒu��ۑ�
        if (_button) 
        {   
            _prePos = _button.transform.position;
        }
        _isSelect = false;
    }

    private void Update()
    {
        //�{�^���������Ă��ăI�u�W�F�N�g���I������Ă����
        if (_button && _isSelect)
        {
            //�������Ă���΂���ɍ��킹�ă{�^���������Ȃ��ʒu��
            if (_isHit)
            {
                _button.transform.position = new Vector3(-300, -300, 0);
            }
            else 
            { 
                //�{�^���̈ʒu��߂�
                ButtonReset(); 
            }

            //�~�܂��Ă�
            if (this.transform.position == _colliderPrePos)
            {
                _isMoved = true;
            }
            //�ړ���
            else
            {
                _isMoved = false;
                _colliderPrePos = this.transform.position;
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Pivot")
        {
            if (_isMoved)
            {
                _isHit = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Pivot")
        {
            _isHit = false;
        }
    }

    //�g���ĂȂ��Ȃ�����Ă��܂��΁H
    public void CheckPostMoveButton()
    {
        if (_button)
        {
            if (_isHit) _button.transform.position = new Vector3(-300, -300, 0);
            else _button.transform.position = _prePos;
        }
    }
    /// <summary>
    /// �{�^�����K��l�֖߂�
    /// </summary>
    public void ButtonReset()
    {
        if (_button) _button.transform.position = _prePos;
    }
    /// <summary>
    /// �{�^���̊��蓖��
    /// </summary>
    void SetBotton()
    {
        //�{�^���������Ă��甲����
        if (_button) return;

        GameObject a = null;
        if (this.gameObject.tag == "Right") a = GameObject.Find("RightButton");
        if (this.gameObject.tag == "Left") a = GameObject.Find("LeftButton");
        if (this.gameObject.tag == "Forward") a = GameObject.Find("ForwardButton");
        if (this.gameObject.tag == "Backward") a = GameObject.Find("BackButton");

        if (a) _button = a.GetComponent<Button>();
    }
}
