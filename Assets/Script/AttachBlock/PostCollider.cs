using UnityEngine;
using UnityEngine.UI;


public class PostCollider : MonoBehaviour
{
    private bool _isHit = false;
    [SerializeField] Button _button;
    public bool _isSelect;
    public bool _isMoved;

    private Vector3 _prePos;

    Vector3 _colliderPrePos;

    private void Start()
    {
        _colliderPrePos = this.transform.position;
        SetBotton();
        if (_button) 
        {   
            _prePos = _button.transform.position;
        }
        _isSelect = false;
    }

    private void Update()
    {
        if (_button && _isSelect)
        {
            if (_isHit)
            {
                _button.transform.position = new Vector3(-300, -300, 0);
            }
            else 
            { 
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

    public void CheckPostMoveButton()
    {
        if (_button)
        {
            if (_isHit) _button.transform.position = new Vector3(-300, -300, 0);
            else _button.transform.position = _prePos;
        }
    }
    public void ButtonReset()
    {
        if (_button) _button.transform.position = _prePos;
    }

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
