using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sureResetLevelTwo : MonoBehaviour
{
    public Sprite hold;
    public Sprite notHold;
    public GameObject canvasExit;
    public Detector detector;
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
        canvasExit.SetActive(false);
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
        canvasExit.SetActive(true);
        detector.inMenu = true;

        

        foreach (GameObject player in dialogue.scientists)
        {
            player.SetActive(false);
        }


        Time.timeScale = 0.0f;

        

    }
}

