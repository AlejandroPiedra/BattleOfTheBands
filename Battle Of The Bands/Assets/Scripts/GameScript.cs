using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public AudioSource song;
    public bool startPlaying;
    public NoteScroller noteScroller;
    public PlayerScript p1;
    public PlayerScript p2;


    void Start()
    {
       
    }

    void Update()
    {
        //Starts Game
        if (!startPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                startPlaying = true;
                noteScroller.startScroll = true;
                song.Play();
            }
        }

        //Check For a Solo
        if (!song.isPlaying)
        {
            if(p1.health > p2.health)
            {
                //P1 Solo
            }
            if (p2.health > p1.health)
            {
                //P2 Solo
            }
        }

        //Check Win/Loss
        if(p1.health <= 0)
        {
            
        }
        if (p2.health <= 0)
        {
           
        }
    }
}
