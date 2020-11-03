using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource song;
    public bool startPlaying;
    public NoteScroller noteScroller;

    void Start()
    {
        
    }
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                startPlaying = true;
                noteScroller.startGame = true;
                song.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("-1 HP TO ENEMY");
    }

    public void NoteMissed()
    {
        Debug.Log("-1 HP TO YOU");
    }
}
