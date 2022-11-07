using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveObjMagic : MonoBehaviour
{
	ObjectCameraController obj;
	[SerializeField] LayerMask _layerMask;
	Button button;
	public float rayDist = 18;

	public Button _Up;
	public Button _Down;
	public Button _Left;
	public Button _Right;

	Vector3 _Position;
	public Vector3 Position
	{
		get { return _Position; }
		set { _Position = value; }
	}

	PlayerMove _Player;

	void Start()
    {
		PlayerMove p = GameObject.Find("player").GetComponent<PlayerMove>();
		if (p != null) _Player = p.GetComponent<PlayerMove>();

		Button b = GameObject.Find("Cancel").GetComponent<Button>();
		obj = GameObject.Find("ObjectCAM").GetComponent<ObjectCameraController>();
		if(b != null)	button = b.GetComponent<Button>();
	}

	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Debug.DrawRay(Camera.main.transform.position, ray.direction * rayDist, Color.green);
		if (Physics.Raycast(ray, out hit, rayDist, _layerMask))
		{
			Gimmick g = hit.collider.gameObject.GetComponent<Gimmick>();
			Transform pos = hit.collider.gameObject.GetComponent<Transform>();
			CubeForceControll _cube = hit.collider.gameObject.GetComponent<CubeForceControll>();
			if (g)
            {
				g.ChangeColor();

				//　マウスの左クリックで撃つ
				if (Input.GetButtonDown("Fire1"))
				{
					_Player.IsMove = false;

					_cube.Rb.isKinematic = false;
					g.IsSelect = true;
                    if (button) button.onClick.AddListener(g.SelectCancel);
                    obj.SelectObj = g.gameObject;
					if (_Up)_Up.onClick.AddListener(_cube.Forward);
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
	}

}
