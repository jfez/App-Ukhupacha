using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipLineRenderer : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(1, endPoint.position);
    }
}
