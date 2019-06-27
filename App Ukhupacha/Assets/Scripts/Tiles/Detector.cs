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
    public Tilemap outputTilemap;

    public Canvas toolsCanvas;
    public Canvas highlightCanvas;
    public Canvas hudCanvas;
    public EventSystem eventSystem;

    public Sprite blockerSprite;
    public Sprite ropeSprite;
    public Sprite zipSprite;
    public Sprite lightSprite;

    Transform[] canvasChildren;

    Tile inputTile;
    Tile outputTile;

    Vector3 offset;
    Vector3Int coordinate;

    GraphicRaycaster hudRaycaster;
    PointerEventData hudPointEventData;

    public Dialogue dialogue;

    public bool canClick;
    public bool inMenu;

    private void Start()
    {
        offset = new Vector3(0f, grid.cellSize.y/2, 0f);
        canClick = true;
        inMenu = false;
        hudRaycaster = hudCanvas.GetComponent<GraphicRaycaster>();
        canvasChildren = toolsCanvas.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            hudPointEventData = new PointerEventData(eventSystem);
            hudPointEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            hudRaycaster.Raycast(hudPointEventData, results);

            if (results.Count != 0)
            {
                return;
            }

            if (dialogue == null)
            {
                if (canClick && !inMenu)
                {
                    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    coordinate = grid.WorldToCell(mouseWorldPos);
                    inputTile = (Tile)inputTilemap.GetTile(coordinate);
                    outputTile = (Tile)outputTilemap.GetTile(coordinate);

                    if (inputTile == null)
                    {
                        EnableCanvases();
                        canvasChildren[1].transform.gameObject.SetActive(false);
                        canvasChildren[2].transform.gameObject.SetActive(false);
                        canvasChildren[3].transform.gameObject.SetActive(false);
                        canvasChildren[4].transform.gameObject.SetActive(false);
                        canvasChildren[5].transform.gameObject.SetActive(false);
                        AdjustCanvases();
                    }
                    else if (outputTile != null)
                    {
                        if (outputTile.sprite != blockerSprite)
                        {
                            EnableCanvases();
                            canvasChildren[1].transform.gameObject.SetActive(false);
                            canvasChildren[2].transform.gameObject.SetActive(false);
                            canvasChildren[3].transform.gameObject.SetActive(false);
                            canvasChildren[4].transform.gameObject.SetActive(false);
                            canvasChildren[5].transform.gameObject.SetActive(false);
                            AdjustCanvases();
                        }
                        else
                        {
                            EnableCanvases();
                            canvasChildren[1].transform.gameObject.SetActive(false);
                            canvasChildren[2].transform.gameObject.SetActive(false);
                            canvasChildren[3].transform.gameObject.SetActive(false);
                            canvasChildren[4].transform.gameObject.SetActive(false);
                            canvasChildren[5].transform.gameObject.SetActive(true);
                            AdjustCanvases();
                        }

                    }
                    else if (inputTile.sprite == lightSprite)
                    {
                        EnableCanvases();
                        canvasChildren[1].transform.gameObject.SetActive(true);
                        canvasChildren[2].transform.gameObject.SetActive(false);
                        canvasChildren[3].transform.gameObject.SetActive(false);
                        canvasChildren[4].transform.gameObject.SetActive(false);
                        canvasChildren[5].transform.gameObject.SetActive(false);
                        AdjustCanvases();
                    }
                    else if (inputTile.sprite == ropeSprite)
                    {
                        EnableCanvases();
                        canvasChildren[1].transform.gameObject.SetActive(false);
                        canvasChildren[2].transform.gameObject.SetActive(true);
                        canvasChildren[3].transform.gameObject.SetActive(false);
                        canvasChildren[4].transform.gameObject.SetActive(false);
                        canvasChildren[5].transform.gameObject.SetActive(false);
                        AdjustCanvases();
                    }
                    else if (inputTile.sprite == zipSprite)
                    {
                        EnableCanvases();
                        canvasChildren[1].transform.gameObject.SetActive(false);
                        canvasChildren[2].transform.gameObject.SetActive(false);
                        canvasChildren[3].transform.gameObject.SetActive(true);
                        canvasChildren[4].transform.gameObject.SetActive(false);
                        canvasChildren[5].transform.gameObject.SetActive(false);
                        AdjustCanvases();
                    }
                    else if (inputTile.sprite == blockerSprite)
                    {
                        EnableCanvases();
                        canvasChildren[1].transform.gameObject.SetActive(false);
                        canvasChildren[2].gameObject.SetActive(false);
                        canvasChildren[3].transform.gameObject.SetActive(false);
                        canvasChildren[4].transform.gameObject.SetActive(true);
                        canvasChildren[5].transform.gameObject.SetActive(false);
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

    public Vector3 GetPosition()
    {
        return grid.CellToWorld(coordinate) + grid.cellSize/2;
    }

    public Vector3Int GetPositionInt()
    {
        return coordinate;
    }

    public void RefreshTile(Tile t)
    {
        outputTilemap.SetTile(coordinate, t);
        outputTilemap.RefreshTile(coordinate);
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
