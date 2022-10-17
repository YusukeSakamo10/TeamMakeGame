using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjMagic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
	public GameObject _bullet;

    Vector3 _camera2Mouse;
	void Update()
	{
		//　マウスの左クリックで撃つ
		if (Input.GetButtonDown("Fire1"))
		{
			Shot();
		}
	}

	//　敵を撃つ
	void Shot()
	{ 
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Debug.Log(ray);
		Instantiate(_bullet);
		BulletMove obj = _bullet.GetComponent<BulletMove>();
		obj.v = Vector3.Normalize(ray.direction)/100;

		if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Enemy")))
		{
			Destroy(hit.collider.gameObject);
		}
	}
}
