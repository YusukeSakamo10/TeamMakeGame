using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GateController : MonoBehaviour
{
    [SerializeField] GameObject _panel;
    // Start is called before the first frame update
    void Start()
    {
        GameObject pannel = GameObject.Find("SelectPanel");
        if (pannel != null) _panel = pannel;
        _panel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_panel != null)_panel.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (_panel != null) _panel.SetActive(false);
    }
}
