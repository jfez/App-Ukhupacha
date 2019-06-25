using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Detector : MonoBehaviour
{
    public Grid grid;
    public Tilemap inputTilemap;
    public Tilemap renderTilemap;

    public Canvas toolsCanvas;
    public Canvas highlightCanvas;

    public Sprite blockerSprite;
    public Sprite ropeSprite;
    public Sprite zipSprite;

    public Sprite blockerSprite2;
    public Sprite ropeSprite2;
    public Sprite zipSprite2;

    Tile tile;
    Tile renderTile;
    Vector3Int coordinate;
    Vector3 offset;

    Transform[] canvasChildren;

    public Dialogue dialogue;

    public bool canClick;
    public bool inMenu;

    private void Start()
    {
        offset = new Vector3(0f, grid.cellSize.y/2, 0f);
        canClick = true;
        inMenu = false;
        canvasChildren = toolsCanvas.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            if (dialogue == null)
            {
                if (canClick && !inMenu)
                {
                    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    coordinate = grid.WorldToCell(mouseWorldPos);
                    tile = (Tile)inputTilemap.GetTile(coordinate);
                    renderTile = (Tile)renderTilemap.GetTile(coordinate);
                    if (tile == null || renderTile != null && (renderTile.sprite == blockerSprite2 || renderTile.sprite == zipSprite2 || renderTile.sprite == ropeSprite2))
                    {
                        EnableCanvases();
                        canvasChildren[1].transform.gameObject.SetActive(false);
                        canvasChildren[2].transform.gameObject.SetActive(false);
                        canvasChildren[3].transform.gameObject.SetActive(false);
                        AdjustCanvases();
                    }
                    else if (tile.sprite == blockerSprite)
                    {
                        EnableCanvases();
                        canvasChildren[1].transform.gameObject.SetActive(false);
                        canvasChildren[2].gameObject.SetActive(false);
                        canvasChildren[3].transform.gameObject.SetActive(true);
                        AdjustCanvases();
                    }
                    else if (tile.sprite == zipSprite)
                    {
                        EnableCanvases();
                        canvasChildren[1].transform.gameObject.SetActive(false);
                        canvasChildren[2].transform.gameObject.SetActive(true);
                        canvasChildren[3].transform.gameObject.SetActive(false);
                        AdjustCanvases();
                    }
                    else
                    {
                        EnableCanvases();
                        canvasChildren[1].transform.gameObject.SetActive(true);
                        canvasChildren[2].transform.gameObject.SetActive(false);
                        canvasChildren[3].transform.gameObject.SetActive(false);
                        AdjustCanvases();
                    }

                    canClick = false;

                }

                else if (!canClick && !inMenu)
                {
                    toolsCanvas.gameObject.SetActive(false);
                    highlightCanvas.gameObject.SetActive(false);

                    canClick = true;
                }
            }
            


        }

        
    }

    public Vector3Int GetPosition()
    {
        return coordinate;
    }

    public void RefreshTile(Tile t)
    {
        renderTilemap.SetTile(coordinate, t);
        renderTilemap.RefreshTile(coordinate);
    }

    private void EnableCanvases()
    {
        toolsCanvas.gameObject.SetActive(true);
        highlightCanvas.gameObject.SetActive(true);
    }

    private void AdjustCanvases()
    {
        toolsCanvas.transform.position = grid.GetCellCenterWorld(coordinate) + offset;
        highlightCanvas.transform.position = grid.GetCellCenterWorld(coordinate) + offset;
    }
}
