using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TutorialDetector : MonoBehaviour
{
    public Movement tutorialCharacter;

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
    Vector3Int currentObjective;
    Vector3Int[] objectiveCoordinates = new Vector3Int[5];
    public int coordinateCounter = 0;
    public bool pointReached = false;

    GraphicRaycaster hudRaycaster;
    PointerEventData hudPointEventData;

    public Dialogue dialogue;

    public bool canClick;
    public bool inMenu;

    private void Start()
    {
        offset = new Vector3(0f, grid.cellSize.y / 2, 0f);
        canClick = true;
        inMenu = false;
        hudRaycaster = hudCanvas.GetComponent<GraphicRaycaster>();
        canvasChildren = toolsCanvas.GetComponentsInChildren<Transform>();

        objectiveCoordinates[0] = new Vector3Int(0, 4, 0);
        objectiveCoordinates[1] = new Vector3Int(2, 1, 0);
        objectiveCoordinates[2] = new Vector3Int(-4, 0, 0);
        objectiveCoordinates[3] = new Vector3Int(-1, -3, 0);
        objectiveCoordinates[4] = new Vector3Int(-3, -3, 0);

        currentObjective = objectiveCoordinates[coordinateCounter];
    }

    // Update is called once per frame
    void Update()
    {
        if (!highlightCanvas.enabled && pointReached)
        {
            highlightCanvas.gameObject.SetActive(true);
            highlightCanvas.transform.position = grid.GetCellCenterWorld(objectiveCoordinates[coordinateCounter]) + offset;
        }

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

            if (dialogue.started == true)
            {
                if (canClick && !inMenu)
                {
                    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    coordinate = grid.WorldToCell(mouseWorldPos);

                    if (pointReached && coordinate == objectiveCoordinates[coordinateCounter])
                    {
                        if (coordinateCounter == 0)
                        {
                            toolsCanvas.gameObject.SetActive(true);
                            canvasChildren[1].transform.gameObject.SetActive(false);
                            canvasChildren[2].transform.gameObject.SetActive(true);
                            canvasChildren[3].transform.gameObject.SetActive(false);
                            canvasChildren[4].transform.gameObject.SetActive(false);
                            canvasChildren[5].transform.gameObject.SetActive(false);
                            toolsCanvas.transform.position = grid.GetCellCenterWorld(coordinate) + offset;
                        }
                        else if (coordinateCounter == 1)
                        {
                            toolsCanvas.gameObject.SetActive(true);
                            toolsCanvas.transform.position = grid.GetCellCenterWorld(coordinate) + offset;
                            canvasChildren[1].transform.gameObject.SetActive(false);
                            canvasChildren[2].transform.gameObject.SetActive(false);
                            canvasChildren[3].transform.gameObject.SetActive(false);
                            canvasChildren[4].transform.gameObject.SetActive(true);
                            canvasChildren[5].transform.gameObject.SetActive(false);
                        }
                        else if (coordinateCounter == 2)
                        {
                            toolsCanvas.gameObject.SetActive(true);
                            toolsCanvas.transform.position = grid.GetCellCenterWorld(coordinate) + offset;
                            canvasChildren[1].transform.gameObject.SetActive(false);
                            canvasChildren[2].transform.gameObject.SetActive(true);
                            canvasChildren[3].transform.gameObject.SetActive(false);
                            canvasChildren[4].transform.gameObject.SetActive(false);
                            canvasChildren[5].transform.gameObject.SetActive(false);
                        }
                        else if (coordinateCounter == 3)
                        {
                            toolsCanvas.gameObject.SetActive(true);
                            toolsCanvas.transform.position = grid.GetCellCenterWorld(coordinate) + offset;
                            canvasChildren[1].transform.gameObject.SetActive(true);
                            canvasChildren[2].transform.gameObject.SetActive(false);
                            canvasChildren[3].transform.gameObject.SetActive(false);
                            canvasChildren[4].transform.gameObject.SetActive(false);
                            canvasChildren[5].transform.gameObject.SetActive(false);
                        }
                        else
                        {
                            toolsCanvas.gameObject.SetActive(true);
                            toolsCanvas.transform.position = grid.GetCellCenterWorld(coordinate) + offset;
                            canvasChildren[1].transform.gameObject.SetActive(false);
                            canvasChildren[2].transform.gameObject.SetActive(false);
                            canvasChildren[3].transform.gameObject.SetActive(true);
                            canvasChildren[4].transform.gameObject.SetActive(false);
                            canvasChildren[5].transform.gameObject.SetActive(false);
                        }

                    }
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
        return grid.CellToWorld(objectiveCoordinates[coordinateCounter]) + grid.cellSize / 2;
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

    public void ShowTargetTile ()
    {
        pointReached = true;
        highlightCanvas.gameObject.SetActive(true);
        highlightCanvas.transform.position = grid.GetCellCenterWorld(objectiveCoordinates[coordinateCounter]) + offset;
    }
}