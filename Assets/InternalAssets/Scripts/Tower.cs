using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    ScriptableTower tower_data;
    bool is_active = false;
    bool can_shoot = true;
    public void IntantTower(string name, Vector3 pos)
    {
        foreach(ScriptableTower i in DataController.instance.TowerData.Data)
        {
            if (i.Name == name) 
            {
                tower_data = i;
                is_active = true;
                GetComponent<SpriteRenderer>().sprite = tower_data.SpriteTower;
                gameObject.transform.position = pos;
                GetComponent<AudioSource>().clip = tower_data.ShootingSound;
                transform.GetChild(0).GetComponent<CircleCollider2D>().radius = tower_data.PlacingRadius;
                break;
            }
        }
    }
    void Start()
    {
       
    }
    
    IEnumerator ShootCooldown()
    {
        can_shoot = false;
        yield return new WaitForSeconds(1 / tower_data.FireRate);
        can_shoot = true;
    }
    void CheckForEnemy()
    {
        Collider2D[] hits_ = Physics2D.OverlapCircleAll(transform.position, tower_data.ShootingRadius);
        List<GameObject> hits = new List<GameObject>();
        bool enemy_on_look = false;
        bool enemy_on_radius = false;
        for (int i = 0; i < hits_.Length; i++)
        {
            if (hits_[i].tag == "Enemy")
            {
                hits.Add(hits_[i].gameObject);
                enemy_on_look = true;
            }
        }

        if (enemy_on_look)
        {
            int choosen_enemy = 0;
            for (int i = 0; i < hits.Count; i++)
            {
                    if (Vector2.Distance(new Vector2(hits[i].transform.position.x, hits[i].transform.position.y), new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)) <
                        Vector2.Distance(new Vector2(hits[choosen_enemy].transform.position.x, hits[choosen_enemy].transform.position.y), new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)))
                    {
                        choosen_enemy = i;
                    }
            }
            if (Vector2.Distance(new Vector2(hits[choosen_enemy].transform.position.x, hits[choosen_enemy].transform.position.y), new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)) < tower_data.ShootingRadius)
                enemy_on_radius = true;
            if (enemy_on_radius)
            {
                LookAt(hits[choosen_enemy].gameObject);
                transform.rotation = Quaternion.Euler(0, -180, transform.rotation.eulerAngles.z);
                Shoot(hits[choosen_enemy].gameObject);
            }
        }
    }
    void LookAt(GameObject target)
    {
        gameObject.transform.LookAt(target.transform.position, new Vector3(0, 0, 1));
    }
    void Shoot(GameObject target)
    {
        if (can_shoot)
        {
            target.GetComponent<Enemy>().TakeDamage(tower_data.Damage);
            GetComponent<AudioSource>().Play();
            StartCoroutine("ShootCooldown");
        }
    }
    void Update()
    {
        CheckForEnemy();
    }
}
