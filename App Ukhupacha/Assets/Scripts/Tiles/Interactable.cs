using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{

    public Image image;
    public Detector detector;
    public Canvas canvas;

    Tile tile;

    private void OnMouseDown()
    {
        tile = (Tile) ScriptableObject.CreateInstance("Tile");
        tile.sprite = image.sprite;
        detector.RefreshTile(tile);
    }
}
