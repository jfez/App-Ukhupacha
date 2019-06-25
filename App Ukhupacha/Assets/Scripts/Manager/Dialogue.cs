using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject canvasDialogue;
    public GameObject canvasText;
    public Text msgText;
    public Text timeText;
    public GameObject hudCanvas;
    public GameObject exitCanvas;

    private List<string> frases;
    private int index;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        index = -1;

        frases = new List<string>();

        frases.Add("¡EA! ¡A trabajar!");
        frases.Add("");

        msgText.text = "¡Hola explorador!";

        canvasDialogue.SetActive(true);
        canvasText.SetActive(true);
        hudCanvas.SetActive(false);
        exitCanvas.SetActive(false);

        msgText.enabled = true;
        timeText.enabled = false;

        Time.timeScale = 0.0f;

        time = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (index <= 0)
            {
                index++;
                msgText.text = frases[index];
            }
            
        }

        if (index > 0)
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

        if (time <= 0)
        {
            canvasDialogue.SetActive(false);
            canvasText.SetActive(false);
            hudCanvas.SetActive(true);

            timeText.enabled = false;

            //ACTIVAR A LOS CIENTÍFICOS

            Destroy(this);
        }
    }
}
