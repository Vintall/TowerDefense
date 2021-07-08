using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [SerializeField] ScriptableEnemy[] data;
    public ScriptableEnemy[] Data
    {
        get
        {
            return data;
        }
    }
    void Start()
    {
        
    }
}
