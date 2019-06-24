using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Detector : MonoBehaviour
{
    public Grid grid;
    public Tilemap tilemap;
    public Sprite newSprite;

    public Canvas canvas;

    public Canvas secondCanvas;

    Tile tile;
    Vector3Int coordinate;
    Vector3 offset;

    GraphicRaycaster graphicsRaycaster;
    PointerEventData pointerEventData;
    public EventSystem eventSystem;

    private void Start()
    {
        graphicsRaycaster = canvas.GetComponent<GraphicRaycaster>();
        offset = new Vector3(0f, grid.cellSize.y/2, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        pointerEventData = new PointerEventData(eventSystem);
        //Set the Pointer Event Position to that of the mouse position
        pointerEventData.position = Input.mousePosition;

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        graphicsRaycaster.Raycast(pointerEventData, results);

        if (results.Count > 0) return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            coordinate = grid.WorldToCell(mouseWorldPos);
            tile = (Tile) tilemap.GetTile(coordinate);
            if (tile == null)
            {
                canvas.transform.position = grid.GetCellCenterWorld(coordinate) + offset;
                secondCanvas.transform.position = grid.GetCellCenterWorld(coordinate) + offset;
                canvas.gameObject.SetActive(true);
                secondCanvas.gameObject.SetActive(true);

                tile = (Tile)ScriptableObject.CreateInstance("Tile");
            }
            else
            {
                Debug.Log("Me van a destruir");
            }
        }
    }

    public Tile GetTile()
    {
        return tile;
    }

    public Vector3Int GetPosition()
    {
        return coordinate;
    }

    public void RefreshTile(Tile t)
    {
        tilemap.SetTile(coordinate, t);
        tilemap.RefreshTile(coordinate);
    }
}
