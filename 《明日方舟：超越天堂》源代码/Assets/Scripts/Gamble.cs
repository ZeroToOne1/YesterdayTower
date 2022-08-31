using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamble : MonoBehaviour
{
    // Start is called before the first frame update
    public bool wTrigger=false;
    
    void Start()
    {
        GameObject[] ws = GameObject.FindGameObjectsWithTag("抽奖");
        wTrigger = false;
        for(int i=0; i < ws.Length; i++)
        {
            if (ws[i].name != gameObject.name && ws[i].GetComponent<Gamble>().wTrigger)
            {
                wTrigger = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] ws = GameObject.FindGameObjectsWithTag("抽奖");
        for (int i=0; i < ws.Length; i++)
        {
            if (ws[i].name != gameObject.name && ws[i].GetComponent<Gamble>().wTrigger)
            {
                wTrigger = true;
            }
        }
        
    }
}
