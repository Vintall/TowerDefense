using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    [SerializeField] GameObject[] next = new GameObject[1];
    public GameObject[] Next
    {
        get
        {
            return next;
        }
    }
    private void OnDrawGizmos()
    {
        if (gameObject.GetComponent<TrajectoryPoint>())
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.1f);
        }
        else if (gameObject.GetComponent<Spawner>())
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.1f);
        }
        else if (gameObject.GetComponent<Home>())
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, 0.1f);
        }

        Gizmos.color = Color.red;
        for (int i = 0; i < next.Length; i++)
        {
            Gizmos.DrawLine(transform.position, next[i].transform.position);
            Gizmos.DrawSphere(next[i].transform.position - (next[i].transform.position - transform.position) / 4, 0.03f);
        }
    }
}
