using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool dead;
    public GameObject canvasDead;
    public Animator anim;
    public Exit exit;
    public Win win;
    public AudioClip death;
    public AudioClip roping;
    public AudioClip tirolina;
    public AudioClip portal;

    public GameObject init;
    public GameObject end;

    private float vertSpeed;

    private float speed;             
    private Vector2 movement;
    private int dir;
    private bool hold;
    private float maxVertSpeed;
    private AudioSource sound;
    private float speedTirolina;
    private Rigidbody2D rb2d;
    private bool inTirolina;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.4f;
        speedTirolina = 0.5f;
        
        movement = new Vector2(1, 0);
        dir = 1;
        dead = false;
        canvasDead.SetActive(false);
        hold = false;
        vertSpeed = 0.5f;
        maxVertSpeed = -5f;
        sound = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
        inTirolina = false;
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

    void FixedUpdate()
    {

        if (inTirolina)
        {
            // REVISAR
            float fixedSpeed = speedTirolina * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, end.transform.position, fixedSpeed);
        }

        
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            dir = dir * -1;
            // REVISAR --> transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            
        }

        if (collision.gameObject.tag == "Ground")
        {
            anim.SetTrigger("inGround");
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Death")
        {
            canvasDead.SetActive(true);
            dead = true;
            exit.dead = true;
            sound.clip = death;
            sound.Play();
            Time.timeScale = 0.0f;
            

        }

        if (col.gameObject.tag == "Rope" && !hold)
        {
            //GetComponent<Rigidbody2D>().gravityScale = 0.1f;
            anim.SetTrigger("inRope");
            hold = true;
            sound.clip = roping;
            sound.Play();


        }

        if (col.gameObject.tag == "JumpDeath")
        {
            if (GetComponent<Rigidbody2D>().velocity.y < maxVertSpeed)
            {
                canvasDead.SetActive(true);
                dead = true;
                exit.dead = true;
                sound.clip = death;
                sound.Play();
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
            sound.clip = portal;
            sound.Play();


        }

        if (col.gameObject.tag == "Tirolina")
        {
            transform.position.Set(transform.position.x, init.transform.position.y, transform.position.z); 

            inTirolina = true;

            rb2d.isKinematic = true;

            anim.SetTrigger("inZip");

            sound.clip = tirolina;
            sound.Play();



        }

        if (col.gameObject.tag == "EndTirolina")
        {
            inTirolina = false;
            rb2d.isKinematic = false;

            
        }

        


    }
}
