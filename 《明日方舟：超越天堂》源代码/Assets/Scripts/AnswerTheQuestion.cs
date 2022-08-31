using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerTheQuestion : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject wrong;
    public GameObject Rewards;
    //public GameObject fail;
    public GameObject[] Questions;
    public int curent=0;
    float random;
 
    void Start()
    {
        Questions[curent % 10].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        random += Time.time;
        
        
    }

    public void TrueAnswer()
    {
        if(random % 100 >=0 && random % 100 < 20)
        {
            //Rewards.SetActive(true);
            
        }
        else if(random % 100 >=20 && random % 100 < 40)
        {
            //Rewards.SetActive(true);
            
        }
        else if(random % 100 >=40 && random % 100 < 60)
        {
            //Rewards.SetActive(true);
            
        }
        else if(random % 100 >=60 && random % 100 < 90)
        {
            
        }
        else
        {
            GameObject[] ws = GameObject.FindGameObjectsWithTag("抽奖");
            for (int i = 0; i < ws.Length; i++)
            {
               
                ws[i].GetComponent<Gamble>().wTrigger = true;
                
            }
            Rewards.SetActive(true);
            
        }
        
        
        
        Questions[curent++ % 10].SetActive(false);
        Questions[curent % 10].SetActive(true);
        
        
        
    
    }

    public void WrongAnswer()
    {
        
       
        
        Questions[curent++ % 10].SetActive(false);
        Questions[curent % 10].SetActive(true);
        
    }
}
