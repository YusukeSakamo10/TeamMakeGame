using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseControll : MonoBehaviour
{
    [SerializeField]GameObject honPanel;
    bool _poseFlag;

    public bool PoseFlag
    {
        get { return _poseFlag; }
        set { _poseFlag = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _poseFlag = false;
    }

    public void Pose()
    {
        _poseFlag = !_poseFlag;
    }

    // Update is called once per frame
    void Update()
    {
        if(_poseFlag)
        {
            honPanel.SetActive(true);
        }
        else
        {
            honPanel.SetActive(false); ;
        }
    }
}
