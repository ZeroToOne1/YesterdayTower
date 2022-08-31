using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerBehavior : Singleton<GameManagerBehavior>
{
    public Text goldLabel;
    private int gold;

    public Text waveLable;
    public GameObject[] nextWaveLabels;
    public bool gameOver = false;

    public GameObject gameover;

    public GameObject Guide;
    public Text healthLabel;
    public GameObject[] healthIndicator;
    public int totalWays;

    public DefenderBtn ClickedBtn { get; private set; }

    public void PickTower(DefenderBtn towerBtn)
    {
        if(this.gold >= towerBtn.towerPrefab.GetComponent<MonsterData>().levels[0].cost)
        {
            this.ClickedBtn = towerBtn;
            Hover.Instance.Activate(towerBtn.Sprite);
        }
        
    }
    public void BuyMonster()
    {
        this.ClickedBtn = null;
    }
    public int Gold
    {
        get { return gold; }
        set
        {
            gold = value;
            goldLabel.GetComponent<Text>().text = "GOLD: " + gold;
        }
    }

    private int wave;
    public int Wave
    {
        get { return wave; }
        set
        {
            wave = value;
            if (!gameOver)
            {
                for (int i = 0; i < nextWaveLabels.Length; i++)
                {
                    nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
                    
                }
            }
            waveLable.text = "WAVE: " + (wave + 1) + "/" + totalWays;
        }
    }
    //管理玩家血量
    private int health;
    public int Health
    {
        get { return health; }
        set
        {
            // 1
            if (value < health)
            {
                Camera.main.GetComponent<CameraShake>().Shake();
            }
            // 2
            health = value;
            healthLabel.text = "HEALTH: " + health;
            // 3
            if (health <= 0 && !gameOver)
            {
                gameOver = true;
                
                gameover.SetActive(true);

            }
            // 4
            for (int i = 0; i < healthIndicator.Length; i++)
            {
                if (i < Health)
                {
                    healthIndicator[i].SetActive(true);
                }
                else
                {
                    healthIndicator[i].SetActive(false);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "第三关")
        {
            Gold = 600;
        }
        else
        {
            Gold = 350;
        }
        Wave = 0;
        Health = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
