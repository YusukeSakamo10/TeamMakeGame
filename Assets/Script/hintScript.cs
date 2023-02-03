using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintScript : MonoBehaviour
{
    bool hintFlag;
    [SerializeField] GameObject hintPanel;

    // Start is called before the first frame update
    void Start()
    {
        hintFlag = false;
    }

    public void hindFlagChange()
    {
        hintFlag = !hintFlag;
    }

    // Update is called once per frame
    void Update()
    {
        hintPanel.SetActive(hintFlag);
    }
}
