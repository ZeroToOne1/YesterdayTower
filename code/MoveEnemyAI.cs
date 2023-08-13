using Pathfinding;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyAI: MonoBehaviour
{
    //要使得干员攻击怪物，就得给Finaltarget赋值，待解决
    [SerializeField]
    public Transform Finaltarget;// AI敌人的目的地
    private GameManagerBehavior gameManager;
    float x, y, z;
    float interCounter;
    float speedData;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 scale = gameObject.transform.localScale;
        
        scale.x *= -1;//镜像翻转 x,y,z都可以
        gameObject.transform.localScale = scale;

        GameObject[] f = GameObject.FindGameObjectsWithTag("fr");
        for(int i = 0; i < f.Length; i++)
        {
            if (f[i].GetComponent<MonsterData>().CurrentLevel.LevelIndex == 2)
            {
                gameObject.GetComponent<AIPath>().maxSpeed = gameObject.GetComponent<AIPath>().maxSpeed * 0.7f;
                break;
            }
        }
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
        speedData = gameObject.GetComponent<AIPath>().maxSpeed;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float speed = gameObject.GetComponent<AIPath>().maxSpeed;
        if (speed == 0f)
        {
            interCounter += Time.time;
        }
        else if (speedData != speed)
        {
            
            GameObject sprite = (GameObject)gameObject.transform.Find("Sprite").gameObject;
            SkeletonAnimation anim = sprite.GetComponent<SkeletonAnimation>();
            anim.state.AddAnimation(1, "Move", true, 0f);
            Debug.Log("减速");
        }
        if (interCounter >= 10.0f)
        {
            GameObject sprite = (GameObject)gameObject.transform.Find("Sprite").gameObject;
            SkeletonAnimation anim = sprite.GetComponent<SkeletonAnimation>();
            anim.state.AddAnimation(1, "Move", true, 0f);
            gameObject.GetComponent<AIPath>().maxSpeed = speedData;
            interCounter = 0f;
        }
        ifGetDestination();
    }
    public float distanceToGoal()
    {
        float distance = 0;
        distance += Vector3.Distance(
            gameObject.transform.position,
            Finaltarget.position);
        
        return distance;
    }

    private void ifGetDestination()
    {
         Debug.Log("进入判断位置函数");
         Debug.Log("当前对象位置："+gameObject.transform.position +" ，目的地位置:" + Finaltarget.position);
        x = System.Math.Abs(gameObject.transform.position.x - Finaltarget.position.x);
        y = System.Math.Abs(gameObject.transform.position.y - Finaltarget.position.y);
        z = gameObject.transform.position.z - Finaltarget.position.z;
        if (x <= 0.5 && y <= 0.5 && z <= 0.5)//当敌人到达目的地时执行下面语句
        {
            Debug.Log("到目的地");
            Destroy(gameObject);

            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

            GameManagerBehavior gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
            gameManager.Health -= 1;
        }
    }


}