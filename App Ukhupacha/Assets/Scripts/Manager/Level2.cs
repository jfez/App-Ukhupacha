using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2 : MonoBehaviour
{
    public GameObject canvasDialogue;
    public GameObject canvasText;
    public Text msgText;
    public Text timeText;
    public GameObject hudCanvas;
    public GameObject exitCanvas;

    public GameObject[] scientists;
    //public GameObject rockSpawner;
    public bool started;


    private float time;
    private bool countdown;

    // Start is called before the first frame update
    void Start()
    {
        

        //rockSpawner.SetActive(false);

        started = false;

        foreach (GameObject scientist in scientists)
        {
            scientist.SetActive(false);
        }

        msgText.text = "¡Pulsa la pantalla para comenzar el trabajo!";

        canvasDialogue.SetActive(true);
        canvasText.SetActive(true);
        hudCanvas.SetActive(false);
        exitCanvas.SetActive(false);

        msgText.enabled = true;
        timeText.enabled = false;
        countdown = false;
        

        time = 3;

        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !countdown)
        {
            countdown = true;

        }

        if (countdown)
        {
            time -= Time.deltaTime;
            if (msgText.enabled)
            {
                msgText.enabled = false;
                timeText.enabled = true;
                Time.timeScale = 1.0f;
            }

            timeText.text = "" + time.ToString("f0");
        }

        if (time <= 0 && !started)
        {
            canvasDialogue.SetActive(false);
            canvasText.SetActive(false);
            hudCanvas.SetActive(true);

            timeText.enabled = false;

            //ACTIVAR A LOS CIENTÍFICOS
            foreach (GameObject scientist in scientists)
            {
                scientist.SetActive(true);
            }

            //rockSpawner.SetActive(true);

            started = true;
            countdown = false;

            //Destroy(this);
        }
    }
}
