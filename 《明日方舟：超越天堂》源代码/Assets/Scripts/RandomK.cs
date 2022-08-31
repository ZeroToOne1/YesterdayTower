using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomK : MonoBehaviour
{
    // Start is called before the first frame update
    float random;
    public GameObject[] Kan;
    private CanvasGroup canvasGroup0;
    private CanvasGroup canvasGroup1;
    private CanvasGroup canvasGroup2;
    private CanvasGroup canvasGroup3;
    private int scale = 4; //随机比例
    void Start()
    {
        var audio_array = this.gameObject.GetComponents(typeof(AudioSource));
        canvasGroup0 = Kan[0].GetComponent<CanvasGroup>();
        canvasGroup1 = Kan[1].GetComponent<CanvasGroup>();
        canvasGroup2 = Kan[2].GetComponent<CanvasGroup>();
        canvasGroup3 = Kan[3].GetComponent<CanvasGroup>();
        random = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        random += Time.time;
    }
    public void SwitchMaster(int K) //选中第K个干员显示
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == K)
            {
                Kan[i].GetComponent<UI_FadeInFadeOut>().UI_Alpha = 1;
            }
            else
            {
                Kan[i].GetComponent<UI_FadeInFadeOut>().UI_Alpha = 0;
            }
        }
    }
    public void Random()
    {


        if (random % scale >= 0 && random % scale < 1)//浮士德
        {
            SwitchMaster(0);
            random = 0;
            for(int i=0; i< Kan.Length; i++)
            {
                Kan[i].transform.Find("Panel").gameObject.SetActive(false);
            }
            Kan[0].transform.Find("Panel").gameObject.SetActive(true);
        }
        else if (random % scale >= 1 && random % scale < 2)
        {
            SwitchMaster(1);
            random = 0;
            for (int i = 0; i < Kan.Length; i++)
            {
                Kan[i].transform.Find("Panel").gameObject.SetActive(false);
            }
            Kan[1].transform.Find("Panel").gameObject.SetActive(true);
        }
        else if (random % scale >= 2 && random % scale < 3)
        {
            SwitchMaster(2);
            random = 0;
            for (int i = 0; i < Kan.Length; i++)
            {
                Kan[i].transform.Find("Panel").gameObject.SetActive(false);
            }
            Kan[2].transform.Find("Panel").gameObject.SetActive(true);
        }
        else
        {

            SwitchMaster(3);
            random = 0;
            for (int i = 0; i < Kan.Length; i++)
            {
                Kan[i].transform.Find("Panel").gameObject.SetActive(false);
            }
            Kan[3].transform.Find("Panel").gameObject.SetActive(true);
        }
    }
}