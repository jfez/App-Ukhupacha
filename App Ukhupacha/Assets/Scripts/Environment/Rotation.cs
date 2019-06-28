using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private int x;
    private int y;
    private int z;
    
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        y = 0;
        z = -2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x, y, z);
    }
}
