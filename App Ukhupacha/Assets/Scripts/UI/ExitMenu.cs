﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMenu : MonoBehaviour
{
    public Sprite hold;
    public Sprite notHold;
    public GameObject canvasMenu;
    public Exit exitScript;

    private SpriteRenderer buttonSprite;

    private BoxCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        buttonSprite = GetComponent<SpriteRenderer>();
        buttonSprite.sprite = notHold;

        col = GetComponent<BoxCollider2D>();
        col.isTrigger = true;
        //col.size = new Vector2(15.1f, 15.1f);
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
        canvasMenu.SetActive(false);
        Time.timeScale = 1.0f;
        exitScript.paused = false;
    }
}
