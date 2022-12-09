using UnityEngine;
using UnityEngine.UI;


public class PostCollider : MonoBehaviour
{
    private bool _isHit = false;
    [SerializeField] Button _button;
    public bool _isSelect;
    public bool _isMoved;
    /// <summary>
    /// 元ボタン位置を保存するよう
    /// </summary>
    private Vector3 _prePos;
    
    Vector3 _colliderPrePos;

    private void Start()
    {
        //元の位置を開始時に保存
        _colliderPrePos = this.transform.position;
        //ボタンの割り当てをスクリプトから
        SetBotton();
        //ボタンが入ってれば元の位置を保存
        if (_button) 
        {   
            _prePos = _button.transform.position;
        }
        _isSelect = false;
    }

    private void Update()
    {
        //ボタンが入っていてオブジェクトが選択されていれば
        if (_button && _isSelect)
        {
            //当たっていればそれに合わせてボタンを見えない位置へ
            if (_isHit)
            {
                _button.transform.position = new Vector3(-300, -300, 0);
            }
            else 
            { 
                //ボタンの位置を戻す
                ButtonReset(); 
            }

            //止まってる
            if (this.transform.position == _colliderPrePos)
            {
                _isMoved = true;
            }
            //移動中
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

    //使ってないなら消してしまえば？
    public void CheckPostMoveButton()
    {
        if (_button)
        {
            if (_isHit) _button.transform.position = new Vector3(-300, -300, 0);
            else _button.transform.position = _prePos;
        }
    }
    /// <summary>
    /// ボタンを規定値へ戻す
    /// </summary>
    public void ButtonReset()
    {
        if (_button) _button.transform.position = _prePos;
    }
    /// <summary>
    /// ボタンの割り当て
    /// </summary>
    void SetBotton()
    {
        //ボタンが入ってたら抜ける
        if (_button) return;

        GameObject a = null;
        if (this.gameObject.tag == "Right") a = GameObject.Find("RightButton");
        if (this.gameObject.tag == "Left") a = GameObject.Find("LeftButton");
        if (this.gameObject.tag == "Forward") a = GameObject.Find("ForwardButton");
        if (this.gameObject.tag == "Backward") a = GameObject.Find("BackButton");

        if (a) _button = a.GetComponent<Button>();
    }
}
