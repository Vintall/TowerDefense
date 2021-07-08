using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] Sprite map_sprite;
    [SerializeField] Sprite map_building_zones;
    [SerializeField] GameObject map_enemy_trajectory;
    public static MapController instanse;
    
    public Sprite BuildingZone
    {
        get
        {
            return map_building_zones;
        }
    }
    void Start()
    {
        instanse = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
