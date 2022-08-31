using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using Spine.Unity;

public class ShootEnemyAI : MonoBehaviour
{
    public float soundCounter;
    public float bulletCounter;
    public float soundCounter2;
    public float bulletCounter2;
    public GameObject BulletStart1;
    public GameObject BulletStart2;
    public List<GameObject> enemiesInRanges;
    private float lastShotTime, lastSkillTime;
    private MonsterData monsterData;
    float m_timer2 = 0;
    float m_timer1 = 0;
    public float m2_timer2 = 0;
    public float m2_timer1 = 0;
    bool trigger;
    bool trigger2;
    // Start is called before the first frame update

    void OnEnemyDestroy(GameObject enemy)
    {
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
        BulletBehaviorAI bulletComp = newBullet.GetComponent<BulletBehaviorAI>();
        bulletComp.target = target.gameObject;
        bulletComp.startPosition = startPosition;
        bulletComp.targetPosition = targetPosition;


    }
    void Start()
    {
        enemiesInRanges = new List<GameObject>();
        lastShotTime = Time.time;
        monsterData = gameObject.GetComponentInChildren<MonsterData>();
        lastSkillTime = Time.time - 99f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SkeletonAnimation animator = monsterData.CurrentLevel.visualization.GetComponent<SkeletonAnimation>();

        GameObject target = null;
        //using for Buttercup
        
        float minimalEnemyDistance = float.MaxValue;
        foreach (GameObject enemy in enemiesInRanges)
        {
            float distanceToGoal = enemy.GetComponent<MoveEnemyAI>().distanceToGoal();
            if (distanceToGoal < minimalEnemyDistance)
            {
                target = enemy;
                minimalEnemyDistance = distanceToGoal;
            }
        }
        // 2
        if (target != null)
        {
            if (trigger)
            {
                m_timer1 += Time.deltaTime;
                m_timer2 += Time.deltaTime;
            }
            if (trigger2)
            {
                m2_timer1 += Time.deltaTime;
                m2_timer2 += Time.deltaTime;
            }

            if (Time.time - lastSkillTime > monsterData.CurrentLevel.fireRate)
            {
                if (gameObject.GetComponent<MonsterData>().CurrentLevel.LevelIndex == 2)
                {
                    
                    animator.state.SetAnimation(1, "Skill_1", false);
                    trigger2 = true;
                    
                    lastSkillTime = Time.time;
                }
            }
            if (m2_timer1 >= soundCounter2 && target != null && trigger2)
            {

                var audio_array = this.gameObject.GetComponents(typeof(AudioSource));



                {
                    AudioSource ad = (AudioSource)audio_array[monsterData.CurrentLevel.LevelIndex - 1];
                    ad.PlayOneShot(ad.clip);
                }
                m2_timer1 = 0;
            }


            if (m2_timer2 >= bulletCounter2 && target != null && trigger2)
            {
                foreach (GameObject enemy in enemiesInRanges)
                {
                    Shoot(enemy.GetComponent<Collider2D>());
                }
                Debug.Log("skill");
                trigger2 = false;
                animator.state.AddAnimation(1, "Idle", true, 0f);
                m2_timer2 = 0;
            }









            if (Time.time - lastShotTime > monsterData.CurrentLevel.fireRate)
            {
                //animator.SetTrigger("fireShot");

                if (gameObject.GetComponent<MonsterData>().CurrentLevel.LevelIndex == 1)
                {
                    animator.state.SetAnimation(1, "Attack", false);

                    lastShotTime = Time.time;
                    trigger = true;
                }
            }


            if (m_timer1 >= soundCounter && target != null && trigger)
            {

                var audio_array = this.gameObject.GetComponents(typeof(AudioSource));



                {
                    AudioSource ad = (AudioSource)audio_array[monsterData.CurrentLevel.LevelIndex - 1];
                    ad.PlayOneShot(ad.clip);
                }
                m_timer1 = 0f;
            }


            if (m_timer2 >= bulletCounter && target != null && trigger)
            {

                Shoot(target.GetComponent<Collider2D>());
                trigger = false;
                m_timer2 = 0f;

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
            m2_timer1 = 0;
            m2_timer2 = 0;
            trigger = false;
            //trigger2 = false;
       
            
            animator.state.AddAnimation(1, "Idle", true, 0f);
            
            //animator.state.SetAnimation(1, "Idle", false);
            //Animator animator = monsterData.CurrentLevel.visualization.GetComponent<Animator>();
            //animator.SetBool("targetDown",true);
        }

    }
}
