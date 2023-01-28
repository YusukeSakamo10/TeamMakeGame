using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaidanFade : MonoBehaviour
{
    [SerializeField] MeshRenderer rendererK;
    kaidanAnime kaidanM;
    // Start is called before the first frame update
    void Start()
    {
        kaidanM = GameObject.Find("kaidanCollider").GetComponent<kaidanAnime>();
        rendererK = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if(kaidanM.isHit == true)
        {
            StopCoroutine("FadeIn");
            StartCoroutine("FadeOut");
        }
        else
        {
            StopCoroutine("FadeOut");
            StartCoroutine("FadeIn");
        }
    }



    IEnumerator FadeIn()
    {
       for (int i = 0; i < 255; i++)
       {
            rendererK.material.color = rendererK.material.color - new Color32(0, 0, 0, 1);
           yield return new WaitForSeconds(0.1f);
       }
    }

    IEnumerator FadeOut()
    {
       for (int i = 0; i < 255; i++)
       {
            rendererK.material.color = rendererK.material.color + new Color32(0, 0, 0, 1);
           yield return new WaitForSeconds(0.1f);
       }
    }
}
