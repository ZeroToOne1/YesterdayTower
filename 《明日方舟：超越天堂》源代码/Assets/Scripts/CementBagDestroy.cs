using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Timeline;

public class CementBagDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeCounter = 5f;
  
    private Vector3 lastPosition;
    
 
  
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {/*
        GameObject[] Bag = GameObject.FindGameObjectsWithTag("CementBag");
        if(Bag.Length != 0)
        {
            Vector3 temp = gameObject.transform.position;
            Vector3 t = Bag[0].transform.position;
            temp.z = Bag[0].transform.position.z;
           
            for (int i = 1; i < Bag.Length; i++)
            {
                if (gameObject.transform.position.y < Bag[i].transform.position.y && t.y > Bag[i].transform.position.y)
                {
                    temp.z = Bag[i].transform.position.z + 0f;
                    t = Bag[i].transform.position;
                }
            }
            gameObject.transform.position = temp;
        }*/
        
        Vector3 temp = gameObject.transform.position;
        if(temp.y > 4.7f)
        {
            temp.z = -2.9f;
        }
        else if(temp.y > 3.54f)
        {
            temp.z = -3.0f;
        }
        else if(temp.y > 2.12f)
        {
            temp.z = -3.1f;
        }
        else if (temp.y > 0.7f)
        {
            temp.z = -3.2f;
        }
        else if (temp.y > -0.89f)
        {
            temp.z = -3.3f;
        }
        else if (temp.y > -2.23f)
        {
            temp.z = -3.4f;
        }
        else if (temp.y > -4.3f)
        {
            temp.z = -3.5f;
        }
        else if (temp.y > -5f)
        {
            temp.z = -3.6f;
        }
        gameObject.transform.position = temp;
        if (lastPosition != this.transform.position)
        {
            lastPosition = this.transform.position;
            timeCounter = 5f;
        }
       
        else
        {
            
            timeCounter -= Time.deltaTime;
        }
        
        if (timeCounter <= 0f)
        {
            GameObject[] Bag = GameObject.FindGameObjectsWithTag("CementBag");
            GameObject delBag = Bag[0];
            for(int i = 1; i < Bag.Length; i++)
            {
                if((this.transform.position - Bag[i].transform.position).sqrMagnitude 
                    < (this.transform.position - delBag.transform.position).sqrMagnitude)
                {
                    delBag = Bag[i];
                }

                        
            }
            
            
            Destroy(delBag);
            
            
            
            
            
            AstarPath.active.Scan();//实时更新扫描网格，使得可以实时添加障碍物
            
            
            timeCounter = 5f;
            
            

            
            
        }
        
    }
}
