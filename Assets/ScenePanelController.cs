using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePanelController : MonoBehaviour
{
    [SerializeField] GameObject _panel;

    private void Start()
    {
        if(_panel == null)
        {
            GameObject panel = GameObject.Find("NonScene");
            if(panel != null)_panel = panel;
        }
        _panel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_panel)_panel.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        _panel.SetActive(false);
    }
}
