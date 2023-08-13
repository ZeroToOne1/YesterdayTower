using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderBtn : MonoBehaviour
{
    [SerializeField]
    public GameObject towerPrefab;

    [SerializeField]
    private Sprite sprite;

    public GameObject TowerPrefab
    {
        get
        {
            return towerPrefab;
        }
    }

    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
    }

}
