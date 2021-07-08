using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameObject next;
    
    public GameObject Next
    {
        get
        {
            return next;
        }
    }
    void Start()
    {
        next = GetComponent<MapPoint>().Next[0]; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
