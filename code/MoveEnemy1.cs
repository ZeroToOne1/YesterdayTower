using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy1 : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] waypoints; //所有的路标
    public GameObject sprite;
    private GameManagerBehavior gameManager;
    private int currentWaypoint; //敌人当前所在的路标
    private float lastWaypointSwitchTime; //敌人经过上一个路标的时刻
    public float speed;  //敌人的移动速度
    public float newspeed=-1f;
    float interCounter;
    float speedData;
    // Start is called before the first frame update
    void Start()
    {
        RotateIntoMoveDirection();
        lastWaypointSwitchTime = Time.time;
        GameObject[] f = GameObject.FindGameObjectsWithTag("fr");
        for (int i = 0; i < f.Length; i++)
        {
            if (f[i].GetComponent<MonsterData>().CurrentLevel.LevelIndex == 2)
            {
                speed *= 0.7f;
            }
        }
        speedData = speed;
        newspeed = -1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (speed ==0f)
        {
            interCounter += Time.time;
        }
        
        else if(speedData != speed)
        {
            
            SkeletonAnimation anim = sprite.GetComponent<SkeletonAnimation>();
            anim.state.AddAnimation(1, "Move", true, 0f);
            Debug.Log("减速");
            
        }
        if (interCounter >= 2.0f)
        {
            
            SkeletonAnimation anim = sprite.GetComponent<SkeletonAnimation>();
            anim.state.AddAnimation(1, "Move", true, 0f);
            speed = speedData;
            interCounter = 0f;
        }
        // 1  从路标数组中，取出当前路段的开始路标和结束路标
        Vector3 startPosition = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;

        // 2 计算出通过整个路段的距离
        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed; //计算出通过整个路段所需要的时间
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        // 计算出当前时刻应该在的位置
        gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);

        // 3 检查敌人是否已经抵达结束路标
        if (gameObject.transform.position.Equals(endPosition))
        {
            //敌人尚未抵达最终的路标
            if (currentWaypoint < waypoints.Length - 2)
            {
                currentWaypoint++;
                lastWaypointSwitchTime = Time.time;
                RotateIntoMoveDirection();
            }
            else  //敌人抵达了最终的路标
            {
                Destroy(gameObject);

                AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

                //TODO: deduct health
                GameManagerBehavior gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
                gameManager.Health -= 1;
            }
        }
    }
    private void RotateIntoMoveDirection()
    {
        // 1 
        Vector3 newStartPosition = waypoints[currentWaypoint].transform.position;
        Vector3 newEndPosition = waypoints[currentWaypoint + 1].transform.position;
        Vector3 newDirection = (newEndPosition - newStartPosition);
        // 2
        float x = newDirection.x;
        float y = newDirection.y;
        //float rotationAngle = Mathf.Atan2(y, x) * 180 / Mathf.PI;
        // 3

        //GameObject sprite = (GameObject)gameObject.transform.Find("Sprite").gameObject;

        Vector3 scale = sprite.transform.localScale;
        if (sprite.transform.localScale.x >= 0)
        {
            if (x < 0)
            {
                scale.x *= -1;//镜像翻转 x,y,z都可以
                sprite.transform.localScale = scale;

            }

        }
        else
        {
            if (x > 0)
            {
                scale.x *= -1;//镜像翻转 x,y,z都可以
                sprite.transform.localScale = scale;

            }

        }



        //sprite.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
    }
    public float distanceToGoal()
    {
        float distance = 0;
        distance += Vector3.Distance(
            gameObject.transform.position,
            waypoints[currentWaypoint + 1].transform.position);
        for (int i = currentWaypoint + 1; i < waypoints.Length - 1; i++)
        {
            Vector3 startPosition = waypoints[i].transform.position;
            Vector3 endPosition = waypoints[i + 1].transform.position;
            distance += Vector3.Distance(startPosition, endPosition);
        }
        return distance;
    }

    
}

