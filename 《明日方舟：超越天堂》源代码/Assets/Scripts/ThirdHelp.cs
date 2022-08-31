using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ThirdHelp : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public List<GameObject> helps;
    bool trigger = false;
    public float timeCounter = 3f;
    public void Help()
    {
        trigger = true;
        for(int i = 0; i < helps.Count; i++)
        {
            helps[i].SetActive(true);
        }
    }

    private void Update()
    {
        if (trigger)
        {
            timeCounter -= Time.deltaTime;
        }
        if (timeCounter == 0f)
        {
            trigger = false;
            for (int i = 0; i < helps.Count; i++)
            {
                helps[i].SetActive(false);
            }
            timeCounter = 3f;
        }
    }
}
