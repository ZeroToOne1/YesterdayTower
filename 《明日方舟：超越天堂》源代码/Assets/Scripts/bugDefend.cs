using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugDefend : MonoBehaviour
{
	// Start is called before the first frame update
	float bugTimeCounter = 20f;
	public UnityEngine.Video.VideoPlayer video;
	public float timeCounter;
	// Use this for initialization
	private void Update()
	{
		if (!video.isPlaying)
		{
			timeCounter -= Time.deltaTime;
			if (timeCounter < 0)
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene("第一关");
			}
		}
		if (video.isPlaying)
		{
			bugTimeCounter -= Time.deltaTime;
			if (bugTimeCounter < 0)
			{
				bugTimeCounter = 20f;
				UnityEngine.SceneManagement.SceneManager.LoadScene("第一关");
			}
		}
	}

}
