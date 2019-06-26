using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool dead;
    public GameObject canvasDead;
    public Exit exit;
    public Win win;

    private float vertSpeed;

    private float speed;             
    private Vector2 movement;
    private int dir;
    private bool hold;
    private float maxVertSpeed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.7f;
        
        movement = new Vector2(1, 0);
        dir = 1;
        dead = false;
        canvasDead.SetActive(false);
        hold = false;
        vertSpeed = 1f;
        maxVertSpeed = -5f;
    }

    // Update is called once per frame
    void Update()
    {

        

        if (!hold)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime * dir);
            //GetComponent<Rigidbody2D>().gravityScale = 1f;
        }

        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -vertSpeed);
        }



    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            dir = dir * -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            
        }

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Death")
        {
            canvasDead.SetActive(true);
            dead = true;
            exit.dead = true;
            Time.timeScale = 0.0f;

        }

        if (col.gameObject.tag == "Rope")
        {
            //GetComponent<Rigidbody2D>().gravityScale = 0.1f;
            
            hold = true;
            

        }

        if (col.gameObject.tag == "JumpDeath")
        {
            if (GetComponent<Rigidbody2D>().velocity.y < maxVertSpeed)
            {
                canvasDead.SetActive(true);
                dead = true;
                exit.dead = true;
                Time.timeScale = 0.0f;
            }

            else
            {
                if (hold)
                {
                    hold = false;
                }
            }


        }

        if (col.gameObject.tag == "Exit")
        {
            win.scientistsCount++;


        }


    }
}
