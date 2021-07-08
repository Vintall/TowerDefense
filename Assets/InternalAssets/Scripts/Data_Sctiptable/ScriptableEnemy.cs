using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateScriptable/Enemy")]
public class ScriptableEnemy : ScriptableObject
{
    [SerializeField] Sprite sprite;
    [SerializeField] float hp;
    [SerializeField] float speed;
    [SerializeField] int stage_cost;
    [SerializeField] int money_for_kill;
    public int StageCost
    {
        get
        {
            return stage_cost;
        }
    }
    public int MoneyForKill
    {
        get
        {
            return money_for_kill;
        }
    }
    public Sprite SpriteEnemy
    {
        get
        {
            return sprite;
        }
    }
    public float Speed
    {
        get
        {
            return speed;
        }
    }
    public float Hp
    {
        get
        {
            return hp;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
