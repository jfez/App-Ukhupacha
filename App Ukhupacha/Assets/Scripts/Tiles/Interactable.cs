using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{

    public GameObject prefab;
    public Detector detector;
    public Canvas canvas;
    public Tile tile;

    

    Vector3 position;

    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        position = detector.GetPosition();
        Instantiate(prefab, position, prefab.transform.rotation);
        
        

        //tile = (Tile) ScriptableObject.CreateInstance("Tile");
        //tile.sprite = image.sprite;
        detector.RefreshTile(tile);
    }
}
