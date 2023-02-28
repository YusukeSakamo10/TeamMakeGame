using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalContoroller : MonoBehaviour
{
    public GameObject GoalText;
    public GameObject ChaneScene;
    private bool _isGoal = false;
    // Use this for initialization
    void Start()
    {
        _isGoal = false;
        GoalText.SetActive(false);

    }


    void Update()
    {
        
    }
    // Update is called once per frame


   void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (!_isGoal) {
                GetComponent<AudioSource>().Play(); 
                _isGoal=true;
            }
           
            GoalText.SetActive(true);
            //ChaneScene.SetActive(true);
        }
    }
}
