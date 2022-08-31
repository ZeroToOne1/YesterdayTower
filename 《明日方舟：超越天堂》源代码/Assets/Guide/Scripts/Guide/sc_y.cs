using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sc_y : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
    public void StartGame()
    {
         SceneManager.LoadScene("第一关");//level1为我们要切换到的场景
    }
    void OnClick()
    {
       
    }

}
