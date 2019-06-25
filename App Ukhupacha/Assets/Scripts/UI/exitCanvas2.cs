using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitCanvas2 : MonoBehaviour
{
    public Sprite hold;
    public Sprite notHold;
    public GameObject canvasExit;
    public Detector detector;


    private SpriteRenderer buttonSprite;
    private BoxCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        buttonSprite = GetComponent<SpriteRenderer>();
        buttonSprite.sprite = notHold;
        col = GetComponent<BoxCollider2D>();
        col.isTrigger = true;

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
        canvasExit.SetActive(false);
        detector.inMenu = false;
        

    }
}
