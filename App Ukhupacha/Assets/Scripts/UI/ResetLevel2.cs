using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel2 : MonoBehaviour
{
    public Sprite hold;
    public Sprite notHold;

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

        SceneManager.LoadScene("Play2-1");
        Time.timeScale = 1.0f;
    }
}
