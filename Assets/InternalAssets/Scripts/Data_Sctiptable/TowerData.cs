using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData : MonoBehaviour
{
    [SerializeField] ScriptableTower[] data;
    public ScriptableTower[] Data
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
