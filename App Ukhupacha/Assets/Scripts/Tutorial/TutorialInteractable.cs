using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TutorialInteractable : MonoBehaviour
{
    public Canvas dialogueCanvas;
    public GameObject prefab;
    public TutorialDetector detector;
    public Tile tile;

    public Sprite hold;
    public Sprite notHold;

    Movement movement;
    Image buttonSprite;
    Vector3 position;

    void Start()
    {
        buttonSprite = GetComponent<Image>();
        buttonSprite.sprite = notHold;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        movement = player.GetComponent<Movement>();
        
        //if (Time.timeScale == 0.0f) StartCoroutine(UpdateCollider());
    }

    private void OnMouseDown()
    {
        //Time.timeScale = 1.0f;
        //dialogueCanvas.gameObject.SetActive(false);

        movement.speed = 0.4f;
        movement.tutorialPause = false;

        position = detector.GetPosition();
        Instantiate(prefab, position, prefab.transform.rotation);

        detector.RefreshTile(tile);
        detector.coordinateCounter++;
        detector.pointReached = false;
        detector.canClick = false;
    }

    /*IEnumerator UpdateCollider()
    {
        Time.timeScale = 1.0f;
        yield return new WaitForFixedUpdate();
        Time.timeScale = 0.0f;
    }*/

    /*void OnMouseDrag()
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
        position = detector.GetPosition();
        Instantiate(prefab, position, prefab.transform.rotation);
        detector.RefreshTile(tile);
    }*/
}