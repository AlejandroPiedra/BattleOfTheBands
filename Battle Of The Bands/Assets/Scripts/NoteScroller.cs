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

    // Update is called once per frame
    void Update()
    {
        if (!startGame)
        {
            if (Input.anyKeyDown)
            {
                startGame = true;
            }
        }
        else
        {
            transform.position -= new Vector3(0f, tempo * Time.deltaTime, 0f);
        }
    }
}
