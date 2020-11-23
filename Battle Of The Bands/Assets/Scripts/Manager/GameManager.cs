using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameScriptableObject game;
    public bool startPlaying;
    public NoteScroller noteScroller;
    public RectTransform gameOverPanel;
    public Text gameOverText;
    public int soloNoteCounter;
    public ButtonController[] buttons;

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
                game.song.Play();
            }
        }

        //Check Win/Loss
        if (game.player1.health <= 0)
        {
            gameOverText.text = "Player 2 Rocks!!";
            SetUpWin();
        }
        if (game.player2.health <= 0)
        {
            gameOverText.text = "Player 1 Rocks!!";
            SetUpWin();
        }

        //Check For a Solo
        if (!game.song.isPlaying)
        {
            if(game.player1.health > 0 && game.player2.health > 0)
            {
                if (game.player1.health > game.player2.health)
                {
                    Solo(game.player1);
                }
                if (game.player2.health > game.player1.health)
                {
                    Solo(game.player2);
                }
            }
        }
    }

    private void Solo(PlayerScript player)
    {
        
        player.gameObject.SetActive(false);
        SetUpWin();
        gameOverText.color = Color.red;
        gameOverText.text =  player.tag + " SOLO!!!";
        if(soloNoteCounter <= 0)
        {
            gameOverText.color = Color.white;
            gameOverText.text = player.tag + " ROCKS!!!";
        }
        //foreach (ButtonController button in player.buttons)
        //{
        //    if (Input.GetKeyDown(button.keyPressed))
        //    {
        //        soloNoteCounter -= 1;
        //    }
        //}
    }

    private void SetUpWin()
    {
        game.song.Stop();
        noteScroller.startScroll = false;
        gameOverPanel.gameObject.SetActive(true);
    }
}
