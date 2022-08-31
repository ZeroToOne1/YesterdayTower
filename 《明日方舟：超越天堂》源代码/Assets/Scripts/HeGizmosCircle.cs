using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeGizmosCircle : MonoBehaviour
{
    public GameObject attackRange;
    GameObject fa;
    public GameObject Data;
    float scaleData;
    float time = 0f;
    void Start()
    {
        fa = GameObject.FindGameObjectWithTag("father");

        if (gameObject.name == "frstar")
        {
            Data = fa.transform.Find("霜星").gameObject;
        }
        else if(gameObject.name == "frstar2")
        {
            Data = fa.transform.Find("霜星2").gameObject;
        }
        else if (gameObject.name == "w")
        {
            Data = fa.transform.Find("w").gameObject;
        }
        else if (gameObject.name == "浮士德")
        {
            Data = fa.transform.Find("浮士德").gameObject;
        }
        else 
        {
            Data = fa.transform.Find("梅妃").gameObject;
        }
        scaleData = Time.timeScale;
    }

    private void Update()
    {
        if(Time.timeScale >= 1f)
        {
            scaleData = Time.timeScale;
        }
        
        /*
        bool flag = false;
        Collider2D[] col = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetMouseButtonDown(0))
        {
            if (Event.current.OnMouseEnter())
            {
                attackRange.SetActive(true);
                if(Time.timeScale >= 1f)
                {
                    scaleData = Time.timeScale;
                }
            
                Time.timeScale = 0.2f;
            }
            else
            {
                
                        attackRange.SetActive(false);
                        Time.timeScale = scaleData;
                    
                    
                
            
            }
        }*/

    }
    private void OnMouseDown()
    {
        if (Time.timeScale != 0f)
        {
            Debug.Log("nbnbnb");
            attackRange.SetActive(true);
            Data.SetActive(true);
            if (Time.timeScale >= 1f)
            {
                scaleData = Time.timeScale;
            }

            Time.timeScale = 0.2f;
        }
       
        
    }
    private void OnMouseOver()
    {
        if (Time.timeScale != 0f)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(gameObject.transform.parent.gameObject);
                Data.SetActive(false);
                attackRange.SetActive(false);
                Time.timeScale = scaleData;
            }
        }
        
        
    }
    private void OnMouseExit()
    {
        if (Time.timeScale != 0)
        {
            Data.SetActive(false);
            attackRange.SetActive(false);
            Time.timeScale = scaleData;
        }
        
            
        
        
    }
    
}
