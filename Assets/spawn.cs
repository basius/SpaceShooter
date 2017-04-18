using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

    public GameObject ship;

    //The interval
    public float interval = 1;

    //Use this for initilization
    void Start()
    {
        InvokeRepeating("SpawnNext", interval, interval);
    }
    void SpawnNext()
    {
        Instantiate(ship, transform.position, Quaternion.identity);
    }
}
