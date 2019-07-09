using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{

    public GameObject prefab;
    public Detector detector;
    public Tile tile;

    public Sprite hold;
    public Sprite notHold;

    private Image buttonSprite;

    Vector3 position;

    void Start()
    {
        buttonSprite = GetComponent<Image>();
        buttonSprite.sprite = notHold;
    }

    private void OnMouseDown()
    {
        position = detector.GetPosition();
        Instantiate(prefab, position, prefab.transform.rotation);
        detector.RefreshTile(tile);
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
