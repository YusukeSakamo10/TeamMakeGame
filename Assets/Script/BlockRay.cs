using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockRay : MonoBehaviour
{
    [SerializeField] float RayLange = 1.1f;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] GameObject _Up;
    [SerializeField] GameObject _Down;
    [SerializeField] GameObject _Left;
    [SerializeField] GameObject _Right;
    [SerializeField] CubeController _Cube;


    void Start()
    {
        _Cube = GetComponent<CubeController>();
    }

    void Update()
    {
        if (_Cube.IsSelect == true)
        {
            Vector3 rayPosition = new(transform.position.x, transform.position.y, transform.position.z);

            Debug.DrawRay(rayPosition, transform.right * RayLange, Color.red);
            Debug.DrawRay(rayPosition, -transform.right * RayLange, Color.red);
            Debug.DrawRay(rayPosition, transform.forward * RayLange, Color.red);
            Debug.DrawRay(rayPosition, -transform.forward * RayLange, Color.red);

            Ray rayRight = new Ray(rayPosition, transform.right);
            Ray rayLeft = new Ray(rayPosition, -transform.right);
            Ray rayForward = new Ray(rayPosition, transform.forward);
            Ray rayBack = new Ray(rayPosition, -transform.forward);

            if (Physics.Raycast(rayRight, RayLange, _layerMask))
            {
                _Right.SetActive(false);
            }
            else _Right.SetActive(true);
            if (Physics.Raycast(rayLeft, RayLange, _layerMask))
            {
                _Left.SetActive(false);
            }
            else _Left.SetActive(true);
            if (Physics.Raycast(rayForward, RayLange, _layerMask))
            {
                _Up.SetActive(false);
            }
            else _Up.SetActive(true);
            if (Physics.Raycast(rayBack, RayLange, _layerMask))
            {
                _Down.SetActive(false);
            }
            else _Down.SetActive(true);
        }
    }
}
