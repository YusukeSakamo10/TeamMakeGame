using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalContoroller : MonoBehaviour
{
    public GameObject GoalText;
    public GameObject ChaneScene;

    // Use this for initialization
    void Start()
    {

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
            GetComponent<AudioSource>().Play();
            GoalText.SetActive(true);
            //ChaneScene.SetActive(true);
        }
    }
}
