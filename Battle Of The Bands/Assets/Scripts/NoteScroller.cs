using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroller : MonoBehaviour
{
    public float tempo;
    public bool startGame;

    void Start()
    {
        tempo = tempo / 60f;
    }

    void Update()
    {
        if (startGame)
        {
            transform.position -= new Vector3(0f, tempo * Time.deltaTime, 0f);
        }
    }
}
