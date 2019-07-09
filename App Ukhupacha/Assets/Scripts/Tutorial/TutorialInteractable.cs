﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TutorialInteractable : MonoBehaviour
{
    public Canvas dialogueCanvas;
    public GameObject prefab;
    public Detector detector;
    public Tile tile;

    public Sprite hold;
    public Sprite notHold;

    Image buttonSprite;
    Vector3 position;

    void Start()
    {
        buttonSprite = GetComponent<Image>();
        buttonSprite.sprite = notHold;
        if (Time.timeScale == 0.0f) StartCoroutine(UpdateCollider());
    }

    private void OnMouseDown()
    {
        Time.timeScale = 1.0f;
        dialogueCanvas.gameObject.SetActive(false);
        position = detector.GetPosition();
        Instantiate(prefab, position, prefab.transform.rotation);
        detector.RefreshTile(tile);
    }

    IEnumerator UpdateCollider()
    {
        Time.timeScale = 1.0f;
        yield return new WaitForFixedUpdate();
        Time.timeScale = 0.0f;
    }

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