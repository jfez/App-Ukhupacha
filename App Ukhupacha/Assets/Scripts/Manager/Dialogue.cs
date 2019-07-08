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
    public GameObject[] scientists;
    public GameObject ukhuMan;
    public GameObject rockSpawner;
    public bool started;

    private List<string> frases;
    private int index;
    private float time;
    private Vector3 rot;
    private Vector3 pos;
    private Vector3 scl;
    

    // Start is called before the first frame update
    void Start()
    {

        rockSpawner.SetActive(false);

        started = false;

        foreach (GameObject scientist in scientists)
        {
            scientist.SetActive(false);
        }

        index = -1;

        frases = new List<string>();

        frases.Add("Soy Dámaso y te doy la bienvenida al Proyecto Ukhupacha.");
        frases.Add("Ahora que formas parte del proyecto, debes saber que nuestro objetivo es...");
        frases.Add("...asistir a los científicos que nos acompañan para que puedan llegar a lugares de estudio casi inaccesibles.");
        frases.Add("Nosotros abrimos el camino y les tendemos la cuerda para que ellos puedan llegar a su objetivo.");
        frases.Add("De esta forma ellos podrán seguir con su investigación arqueológica");
        frases.Add("¡Y así descubriremos más secretos sobre nuestro pasado!");
        frases.Add("Debemos ayudarles en su camino manteniendo su seguridad...");
        frases.Add("...ya que las travesías a las que nos enfrentamos son muy peligrosas.");
        frases.Add("Así que ante los desafíos que aparezcan debes mostrarte decidido");
        frases.Add("guiando a los científicos en su trayecto");
        frases.Add("instalando cuerdas o tirolinas");
        frases.Add("iluminando el camino");
        frases.Add("o marcando por donde NO deberían pasar.");
        frases.Add("Recuerda, hemos venido a ayudar a nuestros compañeros científicos");
        frases.Add("¡Ninguno de ellos deberá sufrir lesión alguna!");
        frases.Add("¡EA! ¡Manos a la obra!");
        frases.Add("");

        msgText.text = "¡Hola aventurero!";

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
            if (index <= 15)
            {
                index++;
                msgText.text = frases[index];
            }

            if (index == 0)
            {

                rot = new Vector3(0,0,0);
                ukhuMan.transform.rotation = Quaternion.Euler(rot);
                pos = new Vector3(-1, 1.4f, 0);
                ukhuMan.transform.position = pos;
            }

            if (index == 8)
            {

                scl = new Vector3(1.6f, 1.6f, 1.6f);
                ukhuMan.transform.localScale = scl;
                pos = new Vector3(1.4f, 0.7f, 0);
                ukhuMan.transform.position = pos;
            }

            if (index == 15)
            {

                rot = new Vector3(0, 0, 180);
                ukhuMan.transform.rotation = Quaternion.Euler(rot);
                pos = new Vector3(0f, 3f, 0);
                ukhuMan.transform.position = pos;
            }

        }

        if (index > 15 && !started)
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

            //Destroy(this);
        }
    }
}
