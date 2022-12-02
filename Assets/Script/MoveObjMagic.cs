using UnityEngine;
using UnityEngine.UI;

public class MoveObjMagic : MonoBehaviour
{
    ObjectCameraController obj;
    CubeController _saveCube;
    [SerializeField] LayerMask _layerMask;
    Button button;
    public float rayDist = 18;

    public Button _Up;
    public Button _Down;
    public Button _Left;
    public Button _Right;

    PlayerMove _Player;

    opaqueBlock pivot;

    void Start()
    {
        PlayerMove p = GameObject.Find("player").GetComponent<PlayerMove>();
        if (p != null) _Player = p.GetComponent<PlayerMove>();

        Button b = GameObject.Find("Cancel").GetComponent<Button>();
        obj = GameObject.Find("ObjectCAM").GetComponent<ObjectCameraController>();
        if (b != null) button = b.GetComponent<Button>();

        opaqueBlock o = GameObject.Find("pivot").GetComponent<opaqueBlock>();
        if (o != null) pivot = o.GetComponent<opaqueBlock>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(Camera.main.transform.position, ray.direction * rayDist, Color.green);
        if (Physics.Raycast(ray, out hit, rayDist, _layerMask))
        {
            Transform o = hit.collider.gameObject.GetComponent<Transform>();
            Gimmick g = hit.collider.gameObject.GetComponent<Gimmick>();
            CubeController _cube = hit.collider.gameObject.GetComponent<CubeController>();
            
            if (g)
            {
                g.ChangeColor();

                //　マウスの左クリックで撃つ
                if (Input.GetButtonDown("Fire1"))
                {
                    _Player.IsMove = false;

                    if (_saveCube)
                    {
                        ObjFocusCameraClear();
                    }

                    //ピポットにトランスフォームを送る
                    pivot._EndTrans = _cube.transform;

                    g.IsSelect = true;
                    if (button) button.onClick.AddListener(g.SelectCancel);
                    obj.SelectObj = g.gameObject;
                    _cube.IsSelect = true;
                    _cube.SetPosChildBox();
                    _saveCube = _cube;
                    //矢印にオブジェクトごとの操作を割り当てる
                    if (_Up) _Up.onClick.AddListener(_cube.Forward);
                    if (_Down) _Down.onClick.AddListener(_cube.Backward);
                    if (_Right) _Right.onClick.AddListener(_cube.Right);
                    if (_Left) _Left.onClick.AddListener(_cube.Left);

                }
            }
        }
    }

    public void ObjFocusCameraClear()
    {
        obj.SelectObj = null;
        if (_saveCube)
        {
            _saveCube.IsSelect = false;
            _saveCube.SetPosChildBox();
            _saveCube = null;
        }
    }

}
