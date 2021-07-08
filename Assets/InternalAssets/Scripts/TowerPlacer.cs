using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    [SerializeField] GameObject tower_sample;
    [SerializeField] GameObject placing_circle;
    bool active_placing = false;
    GameObject active_game_object;
    string active_scriptable_name;
    int cur_cost;
    GameObject placing_circle_obj;
    public void PlacingActivator(string name)
    {
        if(active_placing)
        {
            active_placing = false;
            Destroy(active_game_object);
        }
        else
        {
            foreach (ScriptableTower i in DataController.instance.TowerData.Data)
            {
                if (i.Name == name)
                {
                    if (i.Cost <= GameController.instanse.Coins)
                    {
                        active_placing = true;
                        active_game_object = new GameObject();
                        active_game_object.AddComponent<SpriteRenderer>();
                        active_game_object.GetComponent<SpriteRenderer>().sprite = i.SpriteTower;
                        placing_circle_obj = Instantiate(placing_circle, active_game_object.transform);
                        placing_circle_obj.transform.position = new Vector3(0, 0, -0.1f);
                        placing_circle_obj.transform.localScale = new Vector3(i.PlacingRadius * 2, i.PlacingRadius * 2, 0.1f);

                        active_scriptable_name = name;
                        cur_cost = i.Cost;
                        break;
                    }
                } 
            }
        }
    }
    public void PlaceTurret()
    {
        if (active_placing && placing_circle_obj.GetComponent<PlacingSphere>().BuildingAccess)
        {
            GameObject buf = Instantiate(tower_sample);
            Vector3 buf_pos = GameController.instanse.Cam.ScreenToWorldPoint(Input.mousePosition);
            buf_pos.z = -1;
            buf.GetComponent<Tower>().IntantTower(active_scriptable_name, buf_pos);
            active_placing = false;
            GameController.instanse.Coins -= cur_cost;
            Destroy(active_game_object);
            Destroy(placing_circle_obj);
        }
    }
    private void OnMouseDown()
    {
        PlaceTurret();
    }
    
    void Update()
    {
        if(active_placing)
        {
            Vector3 buf = GameController.instanse.Cam.ScreenToWorldPoint(Input.mousePosition);
            
            buf.z = -1;
            active_game_object.transform.position = buf;


        }
        if (Input.GetAxis("Fire1") != 0)
        {
            PlaceTurret();
        }
    }
}
