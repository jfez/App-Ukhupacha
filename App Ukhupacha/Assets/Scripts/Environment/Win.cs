using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public int scientistsCount;
    public GameObject canvasWin;

    private int numberScientists;
    
    // Start is called before the first frame update
    void Start()
    {
        scientistsCount = 0;
        numberScientists = 1;
        canvasWin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (scientistsCount >= numberScientists)
        {
            canvasWin.SetActive(true);
        }
    }
}
