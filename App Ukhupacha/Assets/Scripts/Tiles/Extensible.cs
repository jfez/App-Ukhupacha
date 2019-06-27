using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extensible : MonoBehaviour
{
    public float unwrapTime = 0.75f;

    SpriteRenderer[] childObjects;
    int iterator = 0;

    // Start is called before the first frame update
    void Start()
    {
        childObjects = GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < childObjects.Length; i++)
        {
            childObjects[i].gameObject.SetActive(false);
        }
        InvokeRepeating("showPart", 0f, unwrapTime);
    }

    void showPart()
    {
        if (iterator == childObjects.Length)
        {
            CancelInvoke();
            return;
        }
        childObjects[iterator].gameObject.SetActive(true);
        iterator++;
    }
}
