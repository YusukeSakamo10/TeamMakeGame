using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalContoroller : MonoBehaviour
{
    public GameObject GoalText;

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
            GoalText.SetActive(true);

        }
    }
}
