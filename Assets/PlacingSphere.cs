using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingSphere : MonoBehaviour
{
    bool building_access = true;
    public bool BuildingAccess
    {
        get
        {
            return building_access;
        }
    }
    int collision_count = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "BuildingBlock")
        {
            building_access = false;
            if (collision_count == 0)
                GetComponent<MeshRenderer>().material.SetColor(Shader.PropertyToID("_Color"), new Color(255, 0, 0, 0.5f));
            collision_count++;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "BuildingBlock")
            collision_count--;

        if (collision_count == 0)
        {
            GetComponent<MeshRenderer>().material.SetColor(Shader.PropertyToID("_Color"), new Color(0, 255, 0, 0.5f));
            building_access = true;
        }
    }
    public void Update()
    {
        
    }
}
