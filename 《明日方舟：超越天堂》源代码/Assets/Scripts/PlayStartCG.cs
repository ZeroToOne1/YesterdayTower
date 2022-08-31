using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayStartCG : MonoBehaviour
{
    public float timeCounter = 5f;
    float bugTimeCounter = 7f;
    public GameObject CG;
    public GameObject firstScence;
    public VideoPlayer videoplayer;
    public RawImage image;
    public GameObject Text;//提示
    float time = 0f;
    void Awake()
    {
        
        videoplayer = gameObject.GetComponent<VideoPlayer>();
        videoplayer.loopPointReached += GameStart;
        //videoplayer.Prepare();
        //image.texture = videoplayer.texture;


    }


    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetMouseButtonDown(0) || Input.anyKeyDown)
        {
            Text.SetActive(false);
            if (!videoplayer.isPlaying)
            {
                
                videoplayer.Play();
                
            }
        }
        if(!videoplayer.isPlaying)
        {
            time += Time.deltaTime * 4;
            timeCounter -= Time.deltaTime;
            
            if(time % 4 > 2f)
            {
                Text.SetActive(false);
            }
            else
            {
                Text.SetActive(true);
            }
            if (timeCounter < 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("开场");
            }
           
        }
        if (videoplayer.isPlaying)
        {
            bugTimeCounter -= Time.deltaTime;
            if(bugTimeCounter < 0)
            {
                bugTimeCounter = 7f;
                UnityEngine.SceneManagement.SceneManager.LoadScene("开场");
            }
        }
        
    }

    void GameStart(VideoPlayer video)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("开场");
    }
}
