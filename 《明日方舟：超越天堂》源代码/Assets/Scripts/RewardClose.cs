using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardClose : MonoBehaviour
{
    // Start is called before the first frame update
    public float time = 0f;
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 1f)
        {
            gameObject.SetActive(false);
            time = 0f;
        }
    }
    
}
