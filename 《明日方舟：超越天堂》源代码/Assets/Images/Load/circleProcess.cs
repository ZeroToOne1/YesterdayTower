using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class circleProcess : MonoBehaviour {
	
	[SerializeField]
	float speed;
	
	[SerializeField]
	Transform process;
	[SerializeField]
	Transform process1;
	[SerializeField]
	Transform process2;


	[SerializeField]
	Transform indicator;
	
	public int targetProcess{ get; set;}
	public AudioSource FCAudio;
	private float currentAmout = 0;
	
	// Use this for initialization
	void Start () {
		targetProcess = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (currentAmout < targetProcess) {
			Debug.Log("currentAmount:" + currentAmout.ToString());
			
			currentAmout += speed;
			if(currentAmout > targetProcess)
				currentAmout = targetProcess;
			indicator.GetComponent<Text>().text = ((int)currentAmout).ToString() + "%";
			process.GetComponent<Image>().fillAmount = currentAmout/80.0f;
			process1.GetComponent<Image>().fillAmount = currentAmout / 80.0f;
			process2.GetComponent<Image>().fillAmount = currentAmout / 80.0f;
		}
		else if(currentAmout == targetProcess)
        {
			FCAudio.Play();

			SceneManager.LoadScene("Menu");
		}
		
	}
	
	
	public void SetTargetProcess(int target)
	{
		if(target >= 0 && target <= 100)
			targetProcess = target;
	}

}
