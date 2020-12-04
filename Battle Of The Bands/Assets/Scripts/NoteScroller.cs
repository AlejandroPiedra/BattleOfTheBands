using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroller : MonoBehaviour
{
    public float tempo;
    public bool startScroll;

    void Start()
    {
        tempo = tempo / 60f;
    }

    void Update()
    {
        if (startScroll)
        {
            transform.position -= new Vector3(0f, tempo * Time.deltaTime, 0f);
        }
    }
}
