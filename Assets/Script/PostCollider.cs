using UnityEngine;
using UnityEngine.UI;
public class PostCollider : MonoBehaviour
{

    private bool _isHit = false;
    [SerializeField] Button _button;
    public bool _isSelect;

    private Vector3 _prePos;

    private void Start()
    {
        SetBotton();
        if (_button) _prePos = _button.transform.position;
        _isSelect = false;
    }

    private void Update()
    {
        if (_button && _isSelect)
        {
            if (_isHit) _button.transform.position = new Vector3(-300, -300, 0);
            else _button.transform.position = _prePos;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        _isHit = true;
    }
    private void OnTriggerExit(Collider other)
    {
        _isHit = false;
    }

    public void CheckPostMoveButton()
    {
        if (_button)
        {
            if (_isHit) _button.transform.position = new Vector3(-300, -300, 0);
            else        _button.transform.position = _prePos;
        }
    }
    public void ButtonReset()
    {
        if(_button)_button.transform.position = _prePos;
    }

    void SetBotton()
    {
        //ƒ{ƒ^ƒ“‚ª“ü‚Á‚Ä‚½‚ç”²‚¯‚é
        if (_button) return;

        GameObject a = null;
        if (this.gameObject.tag == "Right") a = GameObject.Find("RightButton");
        if (this.gameObject.tag == "Left") a = GameObject.Find("LeftButton");
        if (this.gameObject.tag == "Forward") a = GameObject.Find("ForwardButton");
        if (this.gameObject.tag == "Backward") a = GameObject.Find("BackButton");

        if (a) _button = a.GetComponent<Button>();
    }
}
