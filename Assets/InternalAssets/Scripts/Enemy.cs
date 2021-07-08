using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    ScriptableEnemy enemy_ent;
    float current_hp;
    public void InstantEnemy(GameObject spawn_point, ScriptableEnemy data)
    {
        
        enemy_ent = data;
        gameObject.transform.gameObject.GetComponent<SpriteRenderer>().sprite = enemy_ent.SpriteEnemy;
        transform.position = spawn_point.transform.position;
        current_hp = enemy_ent.Hp;
        cur_trajectory_point = spawn_point;
    }
    GameObject cur_trajectory_point;
    public float Hp
    {
        get
        {
            return current_hp;
        }
    }
    public void TakeDamage(float damage)
    {
        current_hp -= damage;
        if (current_hp <= 0)
        {
            WasKilled();
        }
    }
    void ChangeHpBar()
    {

    }
    void Start()
    {
        
    }
    int next_point_index = 0;
    void ChangeCurPoint()
    {
        cur_trajectory_point = cur_trajectory_point.GetComponent<MapPoint>().Next[next_point_index].gameObject;
        transform.position = cur_trajectory_point.transform.position;
        next_point_index = 0;
        if (cur_trajectory_point.GetComponent<MapPoint>().Next.Length != 1)
        {

            next_point_index = Random.Range(0, cur_trajectory_point.GetComponent<MapPoint>().Next.Length); 
        }
        if (cur_trajectory_point.GetComponent<Home>() != null)
        {
            OnFinish();
        }
    }
    void WasKilled()
    {
        GameController.instanse.Coins += enemy_ent.MoneyForKill;
        Destroy(gameObject);
    }
    void OnFinish()
    {
        Destroy(gameObject);
        GameController.instanse.Lives = GameController.instanse.Lives-1;
    }
    private void OnDestroy()
    {
        GameController.instanse.enemy_counter--;
    }

    void MoveOnPoints()
    {
        Transform next = cur_trajectory_point.GetComponent<MapPoint>().Next[next_point_index].transform;
        Transform cur = cur_trajectory_point.GetComponent<MapPoint>().transform;

        transform.position += (next.position - cur.position).normalized * enemy_ent.Speed;

        bool CheckFourSides(Vector3 a, Vector3 b)
        {
            if ((a.x < 0 && b.x > 0) || (a.x > 0 && b.x < 0)) return true;
            if ((a.y < 0 && b.y > 0) || (a.y > 0 && b.y < 0)) return true;
            return false;
        }

        if (CheckFourSides((next.position - transform.position).normalized,  (next.position - cur.position).normalized))
        {
            ChangeCurPoint();
        }
    }
    void FixedUpdate()
    {
        MoveOnPoints();
    }
}
