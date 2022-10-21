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

	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.green);
		if (Physics.Raycast(ray, out hit, 100f, _layerMask))
		{
			Gimmick g = hit.collider.gameObject.GetComponent<Gimmick>();
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
