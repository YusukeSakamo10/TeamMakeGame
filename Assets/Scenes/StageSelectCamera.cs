using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageSelectCamera : MonoBehaviour
{

    GameObject _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
