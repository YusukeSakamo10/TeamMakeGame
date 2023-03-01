using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetBotton : MonoBehaviour
{
    GameManager _GameManager;

    [SerializeField] Image botton;

    float alpha;

    // Start is called before the first frame update
    void Start()
    {
        GameManager g = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (g != null) _GameManager = g.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_GameManager.MoveCountValue == _GameManager.MaxMoveCount)
        {
            alpha = Mathf.Sin(Time.time + 1) + 1;

            Color A = new Color(botton.color.r, botton.color.g, botton.color.b, alpha);

            botton.color = A;
        }
    }
}
