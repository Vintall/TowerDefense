using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public static DataController instance;
    [HideInInspector]
    TowerData tower_data;
    [HideInInspector]
    EnemyData enemy_data;
    public TowerData TowerData
    {
        get
        {
            return tower_data;
        }
    }
    public EnemyData EnemyData
    {
        get
        {
            return enemy_data;
        }
    }
    private void Awake()
    {
        instance = this;
        tower_data = GetComponent<TowerData>();
        enemy_data = GetComponent<EnemyData>();
    }
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
