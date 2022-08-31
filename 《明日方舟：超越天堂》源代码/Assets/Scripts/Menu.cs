using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public GameObject SettingMenu;
    public GameObject pauseMenu;
    public AudioMixer audioMixer;
    public GameObject onceSpeed;
    public GameObject twiceSpeed;
    public GameObject Pause;
    public GameObject Start;
    public GameObject NoFuncWarning;
    public GameObject Introduce;
    float CurTimeScale=1f;
    public GameObject w;
    public GameObject gamle;
    
    public void IntoMap()
    {
        GameObject.DontDestroyOnLoad(w);
        SceneManager.LoadScene("主线作战");
        
    }
    public void Intofigtures()
    {
        GameObject.DontDestroyOnLoad(w);
        SceneManager.LoadScene("角色图鉴");

    }
    public void PlayGame1()
    {
        Time.timeScale = 1f;
        GameObject.DontDestroyOnLoad(w);
        SceneManager.LoadScene("第一关");
        
    }
    public void PlayGame2()
    {
        Time.timeScale = 1f;
        GameObject.DontDestroyOnLoad(w);
        SceneManager.LoadScene("第二关");

    }
    public void PlayGame3()
    {
        Time.timeScale = 1f;
        GameObject.DontDestroyOnLoad(w);
        SceneManager.LoadScene("第三关");

    }
    public void PlayGame4()
    {
        Time.timeScale = 1f;
        GameObject.DontDestroyOnLoad(w);
        SceneManager.LoadScene("第四关");

    }
    public void PlayGame5()
    {
        Time.timeScale = 1f;
        GameObject.DontDestroyOnLoad(w);
        SceneManager.LoadScene("第五关");

    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Setting()
    {
        SettingMenu.SetActive(true);
    }

    public void SettingReturn()
    {
        SettingMenu.SetActive(false);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Pause.SetActive(false);
        Start.SetActive(true);
        CurTimeScale = Time.timeScale;
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        pauseMenu.SetActive(false);
        Pause.SetActive(true);
        Start.SetActive(false);
        Time.timeScale = CurTimeScale;

    }
    public void ReturnGame()
    {
        pauseMenu.SetActive(false);
        Pause.SetActive(true);
        Start.SetActive(false);
        Time.timeScale = CurTimeScale;
    }

    public void SetVolume(float value)
    {
        audioMixer.SetFloat("MainVolume", value);
    }

    public void TwiceSpeed()
    {
        if(Time.timeScale != 0)
        {
            Time.timeScale = 1f;
            twiceSpeed.SetActive(false);
            onceSpeed.SetActive(true);
        }
        else
        {
            CurTimeScale = 1f;
            twiceSpeed.SetActive(false);
            onceSpeed.SetActive(true);
        }
    }

    public void NormalSpeed()
    {
        if(Time.timeScale != 0)
        {
            Time.timeScale = 2f;
            onceSpeed.SetActive(false);
            twiceSpeed.SetActive(true);
        }
        else
        {
            CurTimeScale = 2f;
            onceSpeed.SetActive(false);
            twiceSpeed.SetActive(true);
        }
    }
    
    public void BackToMenu()
    {
        Time.timeScale = CurTimeScale;
        GameObject.DontDestroyOnLoad(w);
        SceneManager.LoadScene("Menu");
    }

    public void NoFunc()
    {
        NoFuncWarning.SetActive(true);
    }

    public void EmailRet()
    {
        NoFuncWarning.SetActive(false);
    }

    public void Intro()
    {
        Introduce.SetActive(true);
    }

    public void IntroRet()
    {
        Introduce.SetActive(false);
    }
    public void Gam()
    {
        gamle.SetActive(true);
    }
    public void GamleRet()
    {
        gamle.SetActive(false);
    }
}
