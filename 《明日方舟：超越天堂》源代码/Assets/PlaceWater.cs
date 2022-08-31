using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceWater : MonoBehaviour
{
    
    public List<GameObject> enemiesInRanges;
    
    public GameObject monsterPrefab;
    private GameObject monster;
    private GameManagerBehavior gameManager;

    private bool canPlaceMonster()
    {
        int cost = monsterPrefab.GetComponent<MonsterData>().levels[0].cost;
        if (GameManagerBehavior.Instance.ClickedBtn.TowerPrefab.name != "Obstacle-pre")
        {
            return false;
        }
        return monster == null && gameManager.Gold >= cost; //确保金币足够
    }
    private bool canUpdateMonster()
    {
        if (monster != null)
        {
            MonsterData monsterData = monster.GetComponent<MonsterData>();
            MonsterLevel nextLevel = monsterData.getNextLevel();
            if (nextLevel != null) //更高的等级存在
            {
                return gameManager.Gold >= nextLevel.cost; //确保金币足够
            }
        }
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        enemiesInRanges = new List<GameObject>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //UnityEngine.Debug.Log("lbwnb");
            if (Time.timeScale != 0f)
            {
                Placemonster();
            }
            
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Hover.Instance.Deactivate();
        }
    }
    
    void Placemonster()
    {
        // 2
        if (canPlaceMonster())
        {
            // 3
            monster = (GameObject)Instantiate(GameManagerBehavior.Instance.ClickedBtn.TowerPrefab, transform.position, Quaternion.identity);

            AstarPath.active.Scan();//实时更新扫描网格，使得可以实时添加障碍物
            // 4
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
            Hover.Instance.Deactivate();
            GameManagerBehavior.Instance.BuyMonster();
            gameManager.Gold -= monster.GetComponent<MonsterData>().CurrentLevel.cost;
        }
        else if (canUpdateMonster())
        {
            gameManager.Gold -= monster.GetComponent<MonsterData>().CurrentLevel.cost;
            monster.GetComponent<MonsterData>().increaseLevel();
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);

        }
    }
    // Update is called once per frame

    
    void Update()
    {
        
        
    }
}
