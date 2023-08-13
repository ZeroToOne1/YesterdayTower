using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TurnToMenu : MonoBehaviour
{

	// Use this for initialization
	void RestartLevel()
	{
		SceneManager.LoadScene("主线作战");
	}

}
