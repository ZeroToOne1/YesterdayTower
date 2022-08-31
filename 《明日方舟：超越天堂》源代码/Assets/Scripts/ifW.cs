using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifW : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject wtri;
    public GameObject w;
    public bool f;
    void Start()
    {
        
        if (wtri.GetComponent<Gamble>().wTrigger)
        {
            w.SetActive(true);
        }
        else
        {
            w.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (wtri.GetComponent<Gamble>().wTrigger)
        {
            w.SetActive(true);
            f = true;
        }
        else
        {
            w.SetActive(false);
            f = false;
        }
    }
}
