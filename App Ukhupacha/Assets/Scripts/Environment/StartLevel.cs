using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("createScientist", 0f);
    }

    void createScientist ()
    {
        Instantiate(player, transform.position, transform.rotation);
    }
}
