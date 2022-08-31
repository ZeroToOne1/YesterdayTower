using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using System;
using Spine.Unity;
using System.Threading;

public class KillEnemy : MonoBehaviour
{
    public float soundCounter;
    public float bulletCounter;

    public List<GameObject> enemiesInRanges;
    public GameObject BulletStart1;
    public GameObject BulletStart2;
    private float lastShotTime, distanceToGoal;

    private MonsterData monsterData;
    public float m_timer2 = 0;
    public float m_timer1 = 0;
    bool trigger = false;
    // Start is called before the first frame update

    void OnEnemyDestroy(GameObject enemy)
    {
        lastShotTime = 0;
        distanceToGoal = 0;

        enemiesInRanges.Remove(enemy);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 2
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRanges.Add(other.gameObject);
            EnemyDestructionDelegate del =
                other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }
    // 3
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRanges.Remove(other.gameObject);
            EnemyDestructionDelegate del =
                other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }
    void Shoot(Collider2D target)
    {
        //1

        {
            GameObject bulletPrefab = monsterData.CurrentLevel.bullet;
            // 2
            Vector3 startPosition;
            if (monsterData.CurrentLevel.LevelIndex == 1)
            {
                startPosition = BulletStart1.transform.position;
            }
            else if (monsterData.CurrentLevel.LevelIndex == 2)
            {
                startPosition = BulletStart2.transform.position;
            }
            else
            {
                startPosition = BulletStart1.transform.position;
            }
            Vector3 targetPosition = target.transform.position;
            startPosition.z = bulletPrefab.transform.position.z;
            targetPosition.z = bulletPrefab.transform.position.z;






            // 3
            GameObject newBullet = (GameObject)Instantiate(bulletPrefab);
            newBullet.transform.position = startPosition;
            BulletBehavior bulletComp = newBullet.GetComponent<BulletBehavior>();
            bulletComp.target = target.gameObject;
            bulletComp.startPosition = startPosition;
            bulletComp.targetPosition = targetPosition;

        }




    }
    void Start()
    {
        enemiesInRanges = new List<GameObject>();
        lastShotTime = Time.time;
        monsterData = gameObject.GetComponentInChildren<MonsterData>();



    }


    // Update is called once per frame
    void FixedUpdate()
    {
        SkeletonAnimation animator = monsterData.CurrentLevel.visualization.GetComponent<SkeletonAnimation>();

        GameObject target = null;
        //using for Buttercup


        // 1
        float minimalEnemyDistance = float.MaxValue;
        foreach (GameObject enemy in enemiesInRanges)
        {


            distanceToGoal = enemy.GetComponent<MoveEnemy1>().distanceToGoal();


            if (distanceToGoal < minimalEnemyDistance)
            {
                target = enemy;
                minimalEnemyDistance = distanceToGoal;
            }
        }
        // 2

        if (target != null)
        {
            //Animator animator = monsterData.CurrentLevel.visualization.GetComponent<Animator>();

            //animator.SetBool("targetDown", false);
            if (trigger)
            {
                m_timer1 += Time.deltaTime;
                m_timer2 += Time.deltaTime;
            }
            if (Time.time - lastShotTime > monsterData.CurrentLevel.fireRate)
            {
                //animator.SetTrigger("fireShot");

                animator.state.SetAnimation(1, "Attack", false);
                trigger = true;



                if (m_timer1 >= soundCounter && target != null)
                {

                    var audio_array = this.gameObject.GetComponents(typeof(AudioSource));



                    {
                        AudioSource ad = (AudioSource)audio_array[monsterData.CurrentLevel.LevelIndex - 1];
                        ad.PlayOneShot(ad.clip);
                    }

                }


                if (m_timer2 >= bulletCounter && target != null)
                {

                    Shoot(target.GetComponent<Collider2D>());



                }




                lastShotTime = Time.time;
            }
            // 3
            //Vector3 direction = gameObject.transform.position - target.transform.position;
            float dirx = gameObject.transform.position.x - target.transform.position.x;

            Vector3 scale = gameObject.transform.localScale;

            scale.x *= -1;//镜像翻转 x,y,z都可以
            if (dirx * gameObject.transform.localScale.x > 0)
            {
                gameObject.transform.localScale = scale;
            }

            //gameObject.transform.rotation = Quaternion.AngleAxis(
            // Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI,
            // new Vector3(0, 0, 1));
        }
        else
        {
            //SkeletonAnimation animator = monsterData.CurrentLevel.visualization.GetComponent<SkeletonAnimation>();
            m_timer1 = 0;
            m_timer2 = 0;
            trigger = false;
            if (!animator.AnimationState.Equals("Attack"))
            {
                animator.state.AddAnimation(1, "Idle", true, 0f);
            }
            //animator.state.SetAnimation(1, "Idle", false);
            //Animator animator = monsterData.CurrentLevel.visualization.GetComponent<Animator>();
            //animator.SetBool("targetDown",true);
        }

    }

}

