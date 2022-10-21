using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjMagic : MonoBehaviour
{
	[SerializeField] LayerMask _layerMask;

    // Start is called before the first frame update
    void Start()
    {

    }
	public GameObject _bullet;

    Vector3 _camera2Mouse;
	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.green);
		if (Physics.Raycast(ray, out hit, 100f, _layerMask))
		{

			Debug.Log(ray);
			Debug.Log(hit);


			//Destroy(hit.collider.gameObject);
			Gimmick g = hit.collider.gameObject.GetComponent<Gimmick>();
			Debug.Log(g.transform);
			if (g)
            {
				g.ChangeColor();
            }
		}


		//　マウスの左クリックで撃つ
		if (Input.GetButtonDown("Fire1"))
		{
			
		}
	}



}
