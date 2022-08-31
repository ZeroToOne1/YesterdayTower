using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaceMonster : MonoBehaviour
{
    public GameObject monsterPrefab;
    public int Flag;
    private GameObject monster;
    private GameManagerBehavior gameManager;

    private bool canPlaceMonster()
    {
        //if (GameManagerBehavior.Instance.ClickedBtn.TowerPrefab.name == "Obstacle-pre")
        {
            //return false;
        }
        return monster == null; //确保有干员
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
        
    }
    public void Placemonster()
    {
        // 2
        if (canPlaceMonster())
        {
            // 3
            UnityEngine.Debug.Log("lbwnb");
            monster = (GameObject)Instantiate(GameManagerBehavior.Instance.ClickedBtn.TowerPrefab, transform.position, Quaternion.identity);
            if (!monster.CompareTag("CementBag"))
            {
                if (Flag == 1)
                {
                    AstarPath.active.Scan();//实时更新扫描网格，使得可以实时添加障碍物
                }

                // 4
                AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                audioSource.PlayOneShot(audioSource.clip);
                Hover.Instance.Deactivate();
                GameManagerBehavior.Instance.BuyMonster();
                gameManager.Gold -= monster.GetComponent<MonsterData>().CurrentLevel.cost;
            }
            else
            {
                Destroy(monster);
            }
        }
        else if(canUpdateMonster())
        {
            
            
            
            monster.GetComponent<MonsterData>().increaseLevel();
            gameManager.Gold -= monster.GetComponent<MonsterData>().CurrentLevel.cost;
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
