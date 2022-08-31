using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoldierData : MonoBehaviour
{

    public GameObject[] data;
    public GameObject Ret;

    public void GetData(GameObject Current)
    {
        for (int i = 0; i < data.Length; i++)
        {
            if (Current.tag == data[i].tag)
            {
                data[i].SetActive(true);
            }
        }
        Ret.SetActive(true);
    }





    public void Return()
    {
        for (int i = 0; i < data.Length; i++)
        {
            
            data[i].SetActive(false);
            
            
        }
        Ret.SetActive(false);
    }



}


