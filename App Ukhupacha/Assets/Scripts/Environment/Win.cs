using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public int scientistsCount;
    public GameObject canvasWin;
    public bool win;
    public Dialogue dialogue;

    public int numberScientists;

    private AudioSource victory;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        scientistsCount = 0;
        
        canvasWin.SetActive(false);
        victory = GetComponent<AudioSource>();
        win = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (scientistsCount >= numberScientists && win == false)
        {
            canvasWin.SetActive(true);
            victory.Play();

            

            foreach (GameObject player in dialogue.scientists)
            {
                player.SetActive(false);
            }

            Time.timeScale = 0.0f;

            win = true;


        }
    }
}
