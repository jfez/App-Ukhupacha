using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject canvasMenu;
    public bool paused;

    public GameObject backButton;

    public bool dead;

    
    
    // Start is called before the first frame update
    void Start()
    {
        canvasMenu.SetActive(false);
        paused = false;
        dead = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused && !dead)
        {
            canvasMenu.SetActive(true);
            Time.timeScale = 0.0f;
            paused = true;
            
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            canvasMenu.SetActive(false);
            Time.timeScale = 1.0f;
            paused = false;
        }
    }
}
