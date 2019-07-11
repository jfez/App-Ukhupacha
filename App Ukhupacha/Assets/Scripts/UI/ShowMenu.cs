using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenu : MonoBehaviour
{
    public GameObject canvasMenu;
    public Exit exitScript;

    public Sprite hold;
    public Sprite notHold;

    
    public TutorialDetector detector;


    public Dialogue dialogue;

    private SpriteRenderer buttonSprite;

    private BoxCollider2D col;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        buttonSprite = GetComponent<SpriteRenderer>();
        buttonSprite.sprite = notHold;

        col = GetComponent<BoxCollider2D>();
        col.isTrigger = true;
        //col.size = new Vector2(5.2f, 5.2f);
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void OnMouseDrag()
    {
        buttonSprite.sprite = hold;
    }

    void OnMouseUp()
    {
        buttonSprite.sprite = notHold;
    }

    void OnMouseUpAsButton()
    {
        buttonSprite.sprite = notHold;
        sound.Play();
        canvasMenu.SetActive(true);

        

        foreach (GameObject player in dialogue.scientists)
        {
            player.SetActive(false);
        }

        Time.timeScale = 0.0f;
        exitScript.paused = true;
        detector.inMenu = true;
    }
}
