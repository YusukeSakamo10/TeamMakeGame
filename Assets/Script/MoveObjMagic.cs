using UnityEngine;
using UnityEngine.UI;

public class MoveObjMagic : MonoBehaviour
{
    ObjectCameraController obj;
    CubeController _saveCube;
    [SerializeField] LayerMask _layerMask;
    Button _cancelButton;
    [SerializeField] GameObject _cancelButtonIsSet;
    public float rayDist = 18;
    GameObject _arrowKey;
    public Button _Up;
    public Button _Down;
    public Button _Left;
    public Button _Right;

    PlayerMove _Player;

    opaqueBlock pivot;
    bool isStart = false;

    Transform _preBlockTrans;
    void Start()
    {
        //プレイヤーを探して受け取る
        PlayerMove p = GameObject.Find("Majo").GetComponent<PlayerMove>();
        if (p != null) _Player = p.GetComponent<PlayerMove>();

        //キャンセルボタンを保存する
        Button b = GameObject.Find("Cancel").GetComponent<Button>();
        if (b != null) _cancelButton = b.GetComponent<Button>();

        //選択時のカメラを探してきて保存する
        obj = GameObject.Find("ObjectCAM").GetComponent<ObjectCameraController>();

        opaqueBlock o = GameObject.Find("pivot").GetComponent<opaqueBlock>();
        if (o != null) pivot = o.GetComponent<opaqueBlock>();

        GameObject setKey = GameObject.Find("ObjctKeyController");
        if (setKey)
        {
            _arrowKey = setKey;
        }


    }

    void Update()
    {
        if (!isStart)
        {
            isStart = true;
            StateChangeButton(false);
        }
        //レイキャスト
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(Camera.main.transform.position, ray.direction * rayDist, Color.green);

        if (Physics.Raycast(ray, out hit, rayDist, _layerMask))
        {
            //当たったオブジェクトから
            //オブジェクトの座標系を保存
            Transform o = hit.collider.gameObject.GetComponent<Transform>();
            //ついてるギミック関数を受け取る
            Gimmick g = hit.collider.gameObject.GetComponent<Gimmick>();

            //オブジェクトを動かす関数を受け取る
            CubeController _cube = hit.collider.gameObject.GetComponent<CubeController>();
            //　↑　これ選択されたときに入れたほうがいいんじゃない？ 物によって？

            if (g)
            {
                //オブジェクトが選択されていなければいろを変える
                if (!_saveCube) g.ChangeColor();

                //　マウスの左クリックで撃つ
                if (Input.GetMouseButtonDown(0) && !_saveCube)
                {
                    //プレイヤーが動かないように
                    _Player.IsMove = false;

                    //消してもいいと思うけど
                    //仮に選択されたオブジェクトがまだあれば消す関数を実施
                    if (_saveCube) ObjFocusCameraClear();
                    //矢印をオブジェクトが選択されたときのみ描画
                    if (_arrowKey) StateChangeButton(true);
                    //ピポットにトランスフォームを送る
                    pivot._EndTrans = _cube.transform;

                    //オブジェクトに対する
                    g.IsSelect = true;
                    //キャンセルボタンに、選択されたオブジェクトのギミックコンポーネントより
                    //キャンセルされたら呼ぶ関数を割り当てる
                    if (_cancelButton) _cancelButton.onClick.AddListener(g.SelectCancel);
                    //撮る対象をオブジェクトを撮るカメラに割り当てる
                    obj.SelectObj = g.gameObject;
                    //動かす用のクラスのほうに選択されたことを伝える
                    _cube.IsSelect = true;
                    //オブジェクト周りの動く際の当たり判定オンにする
                    _cube.SetPosChildBox();
                    //選択されたオブジェクトを一時このクラス内に保管する
                    _saveCube = _cube;
                    //前のオブジェクトと今のオブジェクトが同じだったら
                    _cube.Back(_preBlockTrans == _saveCube.transform);

                    //矢印にオブジェクトごとの操作を割り当てる
                    if (_Up) _Up.onClick.AddListener(_cube.Forward);
                    if (_Down) _Down.onClick.AddListener(_cube.Backward);
                    if (_Right) _Right.onClick.AddListener(_cube.Right);
                    if (_Left) _Left.onClick.AddListener(_cube.Left);

                }
            }
        }

    }
    /// <summary>
    /// オブジェクトに対するカメラを解除する
    /// </summary>
    public void ObjFocusCameraClear()
    {
        //カメラの見るオブジェクトを解除
        obj.SelectObj = null;
        StateChangeButton(false);
        //仮に選択されたオブジェクトがあれば選択を解除
        if (_saveCube)
        {
            //一個戻す際、仮に解除した後も戻せるように
            _preBlockTrans = _saveCube.transform;
            //選択オブジェクトを解除してから行動する用のコライダーなど消す
            _saveCube.IsSelect = false;
            _saveCube.SetPosChildBox();
            //オブジェクト完全解除
            _saveCube = null;
        }
    }
    /// <summary>
    /// 矢印ボタンの描画のオンオフ
    /// </summary>
    /// <param name="isSwitch"></param>
    private void StateChangeButton(bool isSwitch)
    {
        if (!_arrowKey) return;
        _arrowKey.SetActive(isSwitch);
        _cancelButtonIsSet.SetActive(isSwitch);
    }


}
