using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScroll : MonoBehaviour
{
    public Scrollbar scrollbar;
    public Vector3 top;
    public Vector3 bottom;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(top, bottom, scrollbar.value);
    }
}
