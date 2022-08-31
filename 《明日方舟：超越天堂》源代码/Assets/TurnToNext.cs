using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TurnToNext : MonoBehaviour
{
	// Use this for initialization
	void RestartLevel()
	{
		Time.timeScale = 1f;
		Scene scene = SceneManager.GetActiveScene();
		if(scene.name == "第三关")
		{
			SceneManager.LoadScene("end");
		}
		else
		{
			SceneManager.LoadScene("Menu");
		}
		
	}
}
