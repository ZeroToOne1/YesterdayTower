using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class MonsterData : MonoBehaviour
{
    public List<MonsterLevel> levels;
    private MonsterLevel currentLevel;

    // 1
    public MonsterLevel CurrentLevel
    {
        //  2
        get
        {
            return currentLevel;
        }
        //  3
        set
        {
            currentLevel = value;
            int currentLevelIndex = levels.IndexOf(currentLevel);

            //根据currentLevelIndex的值，来决定小怪兽的形态
            GameObject levelVisualization = levels[currentLevelIndex].visualization;
            for (int i = 0; i < levels.Count; i++)
            {
                if (levelVisualization != null)
                {
                    if (i == currentLevelIndex)
                    {
                        levels[i].visualization.SetActive(true);
                    }
                    else
                    {
                        levels[i].visualization.SetActive(false);
                    }
                }
            }
        }
    }
    //判断升级的条件
    public MonsterLevel getNextLevel()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        int maxLevelIndex = levels.Count - 1;
        if (currentLevelIndex < maxLevelIndex)
        {
            return levels[currentLevelIndex + 1];
        }
        else
        {
            return null;
        }
    }
    //增加干员等级
    public void increaseLevel()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        if (currentLevelIndex < levels.Count - 1)
        {
            CurrentLevel = levels[currentLevelIndex + 1];
        }
    }
    void OnEnable()
    {
        CurrentLevel = levels[0];
    }
}
[System.Serializable]
public class MonsterLevel
{
    public int cost; //召唤怪物所消耗的金币
    public GameObject visualization;    //怪物在某个特定等级的视觉效果、
    public int LevelIndex;
    public GameObject bullet;
    public float fireRate;
}