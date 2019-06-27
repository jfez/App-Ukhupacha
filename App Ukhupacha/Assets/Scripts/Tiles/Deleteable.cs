using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Deleteable : MonoBehaviour
{
    public Detector detector;
    public Tilemap outputTilemap;

    public AudioSource sound;

    Vector3Int position;

    void Start()
    {
        
    }


    private void OnMouseDown()
    {
        position = detector.GetPositionInt();
        outputTilemap.SetTile(position, null);
        outputTilemap.RefreshTile(position);

        //Ray ray = Camera.main.ScreenPointToRay(detector.GetPosition());
        RaycastHit2D hit = Physics2D.Raycast(detector.GetPosition(), Vector2.down);

        if (hit.collider != null)
        {
            Destroy(hit.transform.gameObject);
            sound.Play();
        }
    }
}
