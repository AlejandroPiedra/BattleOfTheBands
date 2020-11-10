using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public AudioSource song;
    public bool startPlaying;
    public NoteScroller noteScroller;
    public PlayerScript p1;
    public PlayerScript p2;
    public RectTransform gameOverPanel;
    public Text gameOverText;
    public Button gameOverButton;
    public int soloNoteCounter = 25;


    //Set Up Game Screen
    void Start()
    {
        //Get Both Players Band
        //Get the Song (Depending on the Bands chosen)
        //Set Up the Songs notes for both players
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
                song.Stop();
                noteScroller.startScroll = false;
                Solo(p1);
            }
            if (p2.health > p1.health)
            {
                //P2 Solo
            }
        }

        //Check Win/Loss
        if(p1.health <= 0)
        {
            SetUpWin();
            gameOverText.text = "Player 1 Rocks!!";
        }
        if (p2.health <= 0)
        {
            SetUpWin();
            gameOverText.text = "Player 2 Rocks!!";
        }
    }

    private void Solo(PlayerScript player)
    {
        if(soloNoteCounter <= 0)
        {
            gameOverText.text = player.tag + " Rocks";
            SetUpWin();
        }
        foreach (ButtonController button in player.buttons)
        {
            if (Input.GetKeyDown(button.keyPressed))
            {
                soloNoteCounter -= 1;
            }
        }
    }

    private void SetUpWin()
    {
        song.Stop();
        noteScroller.startScroll = false;
        gameOverPanel.gameObject.SetActive(true);
    }
}
