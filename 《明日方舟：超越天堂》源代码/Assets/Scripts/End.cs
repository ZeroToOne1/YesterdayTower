using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
public class End : MonoBehaviour
{
    float bugTimeCounter = 16f;
    VideoPlayer videoplayer;
    public float timeCounter;
    void Start()
    {
        videoplayer = gameObject.GetComponent<VideoPlayer>();
        videoplayer.loopPointReached += GameStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (videoplayer.isPlaying)
            {

                videoplayer.Stop();
                SceneManager.LoadScene("Menu");

            }
        }
        if (!videoplayer.isPlaying)
        {
            timeCounter -= Time.deltaTime;
            if (timeCounter < 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }
        if (videoplayer.isPlaying)
        {
            bugTimeCounter -= Time.deltaTime;
            if (bugTimeCounter < 0)
            {
                bugTimeCounter = 16f;
                SceneManager.LoadScene("Menu");
            }
        }
    }
    void GameStart(VideoPlayer video)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
