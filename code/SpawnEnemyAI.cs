using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Linq;
using System.Collections.Specialized;

[System.Serializable]
public class Wave1
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2;
    public int maxEnemies = 20;
}
public class SpawnEnemyAI : MonoBehaviour
{
    //public GameObject[] waypoints;  //存储路标
    public GameObject testEnemyPrefab; //保存对Enemyprefab的引用
    // Start is called before the first frame update
    public Wave1[] waves;
    public int[] wavesindex;
  
    public int timeBetweenWaves = 5;

    private GameManagerBehavior gameManager;

    private float lastSpawnTime;
    private int enemiesSpawned = 0;
    
    Vector3 Destation;
    void Start()
    {

        lastSpawnTime = Time.time;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();

    }
   
    // Update is called once per frame
    void Update()
    {
        // 1
        int currentWave = gameManager.Wave;

        if (currentWave < waves.Length)
        {   // 2
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[currentWave].spawnInterval;
            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
                timeInterval > spawnInterval) &&
                enemiesSpawned < waves[currentWave].maxEnemies)
            {   // 3
                lastSpawnTime = Time.time;

                if (currentWave <= wavesindex[0] - 1)
                {
                    UnityEngine.Debug.Log("lbwnb");
                    GameObject newEnemy = (GameObject)Instantiate(waves[currentWave].enemyPrefab);
                    GameObject newEnemy1 = (GameObject)Instantiate(waves[currentWave].enemyPrefab);
                    Destation.x = 8.98288f;
                    Destation.y = -0.7218096f;
                    Destation.z = newEnemy.transform.position.z;
                    newEnemy.transform.position = Destation;

                    Destation.x = 8.03f;
                    Destation.y = 2.31f;
                    Destation.z = newEnemy1.transform.position.z;
                    newEnemy1.transform.position = Destation;
                }
                else if(currentWave <= wavesindex[1] - 1)
                {
                    GameObject newEnemy = (GameObject)Instantiate(waves[currentWave].enemyPrefab);
                    GameObject newEnemy1 = (GameObject)Instantiate(waves[currentWave].enemyPrefab);
                    Destation.x = 8.03f;
                    Destation.y = 2.31f;
                    Destation.z = newEnemy.transform.position.z;
                    newEnemy.transform.position = Destation;

                    Destation.x = 8.98288f;
                    Destation.y = -0.7218096f;
                    Destation.z = newEnemy1.transform.position.z;
                    newEnemy1.transform.position = Destation;
                }
                else if (currentWave <= wavesindex[2] - 1)
                {
                    GameObject newEnemy = (GameObject)Instantiate(waves[currentWave].enemyPrefab);
                    GameObject newEnemy1 = (GameObject)Instantiate(waves[currentWave].enemyPrefab);
                    GameObject newEnemy2 = (GameObject)Instantiate(waves[currentWave].enemyPrefab);
                    Destation.x = -5.2f;
                    Destation.y = -4.5f;
                    Destation.z = newEnemy.transform.position.z;
                    newEnemy.transform.position = Destation;

                    Destation.x = 8.98288f;
                    Destation.y = -0.7218096f;
                    Destation.z = newEnemy1.transform.position.z;
                    newEnemy1.transform.position = Destation;

                    Destation.x = 8.03f;
                    Destation.y = 2.31f;
                    Destation.z = newEnemy2.transform.position.z;
                    newEnemy2.transform.position = Destation;
                }
                else if (currentWave <= wavesindex[3] - 1)
                {
                    GameObject newEnemy = (GameObject)Instantiate(waves[currentWave].enemyPrefab);
                    Destation.x = 7.2f;
                    Destation.y = 1.6f;
                    Destation.z = newEnemy.transform.position.z;
                    newEnemy.transform.position = Destation;
                }


                //将敌人的目的地传到MoveEnemy里面
                // newEnemy.GetComponent<MoveEnemyAI>().Finaltarget = GetComponent<AIDestinationSetter>().target;
                // Debug>Log("掉血");
                enemiesSpawned++;
            }
            // 4 
            if (enemiesSpawned == waves[currentWave].maxEnemies &&
                GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                gameManager.Wave++;
                gameManager.Gold = Mathf.RoundToInt(gameManager.Gold * 1.1f);
                enemiesSpawned = 0;
                lastSpawnTime = Time.time;
            }
        }  // 5
        else
        {
            gameManager.gameOver = true;
            GameObject gameOverText = GameObject.FindGameObjectWithTag("GameWon");
            gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
        }
    }
}