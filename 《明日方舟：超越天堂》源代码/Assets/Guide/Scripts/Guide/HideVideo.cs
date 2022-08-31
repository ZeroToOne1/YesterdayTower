using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class HideVideo : MonoBehaviour
{
    public VideoPlayer videoplayer;

    void Awake()
    {

        videoplayer = gameObject.GetComponent<VideoPlayer>();
        videoplayer.loopPointReached += Dest;
        //videoplayer.Prepare();
        //image.texture = videoplayer.texture;


    }


    // Update is called once per frame
  

    void Dest(VideoPlayer video)
    {
        Destroy(GetComponent<VideoPlayer>());
    }


}
