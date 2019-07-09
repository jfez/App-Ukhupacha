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
    
    public AudioClip roping;
    public AudioClip tirolina;
    public AudioSource portal;
    public AudioSource lvlMusic;
    public AudioSource death;

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;

    private GameObject init;
    private GameObject end;

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

    public bool stop1;
    public bool stop2;
    public bool stop3;
    public bool stop4;
    public bool stop5;

    private bool helmet;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.4f;
        speedTirolina = 2f;
        
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

        stop1 = false;
        stop2 = false;
        stop3 = false;
        stop4 = false;
        stop5 = false;

        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(false);

        helmet = true;


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
            
            transform.GetChild(1).localScale = new Vector3(transform.GetChild(1).localScale.x * -1, transform.GetChild(1).localScale.y, transform.GetChild(1).localScale.z);
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
            
            death.Play();
            GameObject[] players;
            players = GameObject.FindGameObjectsWithTag("Player");

            foreach (GameObject player in players)
            {
                Destroy(player.transform.GetChild(1).gameObject);
            }
            lvlMusic.Stop();
            Time.timeScale = 0.0f;
            

        }

        if (col.gameObject.tag == "RockDeath")
        {
            if (helmet)
            {
                helmet = false;
                //print("mi gorro!!");
                Destroy(col.gameObject);
            }

            else
            {
                canvasDead.SetActive(true);
                dead = true;
                exit.dead = true;

                death.Play();
                GameObject[] players;
                players = GameObject.FindGameObjectsWithTag("Player");

                foreach (GameObject player in players)
                {
                    Destroy(player.transform.GetChild(1).gameObject);
                }
                lvlMusic.Stop();
                Time.timeScale = 0.0f;
            }

            


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

                death.Play();
                GameObject[] players;
                players = GameObject.FindGameObjectsWithTag("Player");

                foreach (GameObject player in players)
                {
                    Destroy(player);
                }
                lvlMusic.Stop();

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
            gameObject.SetActive(false);
            
            portal.Play();


        }

        if (col.gameObject.tag == "Tirolina")
        {
            init = GameObject.FindGameObjectWithTag("Tirolina");
            end = GameObject.FindGameObjectWithTag("EndTirolina");

            //Time.timeScale = 0.1f;

            transform.position.Set(transform.position.x, init.transform.position.y, transform.position.z); 

            inTirolina = true;

            rb2d.isKinematic = true;

            anim.SetTrigger("inZip");

            sound.clip = tirolina;
            sound.Play();

            //print(inTirolina);



        }

        if (col.gameObject.tag == "EndTirolina")
        {
            inTirolina = false;
            rb2d.isKinematic = false;
            //print("exit tirolina");

            
        }

        if (col.gameObject.tag == "Stop1" && !stop1)
        {
            text1.SetActive(true);
            stop1 = true;
            Time.timeScale = 0.0f;

        }

        if (col.gameObject.tag == "Stop2" && !stop2)
        {
            text2.SetActive(true);
            stop2 = true;
            Time.timeScale = 0.0f;

        }

        if (col.gameObject.tag == "Stop3" && !stop3)
        {
            text1.SetActive(true);
            stop3 = true;
            Time.timeScale = 0.0f;

        }

        if (col.gameObject.tag == "Stop4" && !stop4)
        {
            text3.SetActive(true);
            stop4 = true;
            Time.timeScale = 0.0f;

        }

        if (col.gameObject.tag == "Stop5" && !stop5)
        {
            text4.SetActive(true);
            stop5 = true;
            Time.timeScale = 0.0f;

        }

    }
}
