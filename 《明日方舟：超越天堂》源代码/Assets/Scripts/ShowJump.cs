using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowJump : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject talk;
    public void backToMenu()
    {
        talk.SetActive(false);
        SceneManager.LoadScene("Menu");
    }
}
