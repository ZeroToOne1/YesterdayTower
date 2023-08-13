﻿using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 10;
    public int damage;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    public bool Flag = false;
    private float distance;
    private float startTime;

    private GameManagerBehavior gameManager;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        distance = Vector3.Distance(startPosition, targetPosition);
        GameObject gm = GameObject.Find("GameManager");
        gameManager = gm.GetComponent<GameManagerBehavior>();
    
    }

    // Update is called once per frame
    void Update()
    {


        //0
        if (!Flag)
        {
            Vector3 direction = gameObject.transform.position - targetPosition;
            gameObject.transform.rotation = Quaternion.AngleAxis(
             Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI,
             new Vector3(0, 0, 1));
            // 1
            
        }
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);
        
        // 2
        if (gameObject.transform.position.Equals(targetPosition))
        {
            if (target != null)
            {
                // 3
                Transform healthBarTransform = target.transform.Find("HealthBar");
                HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
                healthBar.currentHealth -= Mathf.Max(damage, 0);
                // 4
                if (healthBar.currentHealth <= 0)
                {
                    Destroy(target);
                    AudioSource audioSource = target.GetComponent<AudioSource>();
                    AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

                    gameManager.Gold += 40;
                }
                
                SkeletonAnimation anim = target.transform.Find("Sprite").gameObject.GetComponent<SkeletonAnimation>();
                anim.state.SetAnimation(1, "Interact", false);
                if (this.gameObject.layer.Equals(target.transform.Find("Sprite").gameObject.layer))
                {
                    Debug.Log("先减速");
                    if(target.GetComponent<MoveEnemy1>().speed * 0.8f > 0.8f)
                    {
                        target.GetComponent<MoveEnemy1>().speed = target.GetComponent<MoveEnemy1>().speed * 0.9f;

                    }
                }
                else
                {
                    target.GetComponent<MoveEnemy1>().speed = 0f;
                }
               
                
                
                
            }
            Destroy(gameObject);
        }
    }
    
}
