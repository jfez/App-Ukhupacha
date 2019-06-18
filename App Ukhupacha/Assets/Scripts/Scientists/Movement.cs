using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed;             
    private Vector2 movement;
    private int dir;   

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        
        movement = new Vector2(1, 0);
        dir = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.right * speed * Time.deltaTime * dir);

        if (Input.GetMouseButtonDown(0))
        {
            dir = dir * -1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //dir = dir * -1;
        }
    }
}
