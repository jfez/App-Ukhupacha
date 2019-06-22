using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public float intervalTime = 2f;
    public Transform spawn;
    public GameObject rock;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Create", 0.0f, intervalTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create()
    {
        GameObject maleta = Instantiate(rock, spawn.position, Quaternion.identity);
    }
}
