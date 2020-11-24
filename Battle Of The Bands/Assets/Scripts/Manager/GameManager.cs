using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameScriptableObject game;
    public AudioSource song;
    public bool startPlaying;
    public NoteScroller noteScroller;
    public RectTransform gameOverPanel;
    public Text gameOverText;
    public int soloNoteCounter;
    public ButtonController[] p1buttons;
    public ButtonController[] p2buttons;

    public int p1damageMultiplier;
    public int p1multiplierTracker;
    public int[] p1multiplierArray;
    public Text p1healthDisplay;
    public Text p1comboDisplay;
    public int p2damageMultiplier;
    public int p2multiplierTracker;
    public int[] p2multiplierArray;
    public Text p2healthDisplay;
    public Text p2comboDisplay;


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

        for (int i = 0; i < p1buttons.Length; i++)
        {
            if (Input.GetKeyDown(p1buttons[i].keyPressed))
            {
                if (p1buttons[i].noteHit)
                {
                    if (p1damageMultiplier - 1 < p1multiplierArray.Length)
                    {
                        p1multiplierTracker++;
                        if (p1multiplierArray[p1damageMultiplier - 1] <= p1multiplierTracker)
                        {
                            p1multiplierTracker = 0;
                            p1damageMultiplier++;
                            p1comboDisplay.text = "x" + p1damageMultiplier;
                        }
                    }
                    game.player2.health -= 1 * p1damageMultiplier;
                    p2healthDisplay.text = "HP: " + game.player2.health;
                    p1buttons[i].noteHit = false;
                }
                else
                {
                    p1multiplierTracker = 0;
                    p1damageMultiplier = 1;
                    game.player1.health -= 1;
                    p1healthDisplay.text = "HP: " + game.player1.health;
                    p1comboDisplay.text = "x" + p1damageMultiplier;
                }
            }
            if (p1buttons[i].noteMiss)
            {
                p1buttons[i].noteMiss = false;
                p1multiplierTracker = 0;
                p1damageMultiplier = 1;
                p1comboDisplay.text = "x" + p1damageMultiplier;
                game.player1.health -= 1;
                p1healthDisplay.text = "HP: " + game.player1.health;
            }

            if (Input.GetKeyDown(p2buttons[i].keyPressed))
            {
                if (p2buttons[i].noteHit)
                {
                    if (p2damageMultiplier - 1 < p2multiplierArray.Length)
                    {
                        p2multiplierTracker++;
                        if (p2multiplierArray[p2damageMultiplier - 1] <= p2multiplierTracker)
                        {
                            p2multiplierTracker = 0;
                            p2damageMultiplier++;
                            p2comboDisplay.text = "x" + p2damageMultiplier;
                        }
                    }
                    game.player1.health -= 1 * p2damageMultiplier;
                    p1healthDisplay.text = "HP: " + game.player1.health;
                    p2buttons[i].noteHit = false;
                }
                else
                {
                    p2multiplierTracker = 0;
                    p2damageMultiplier = 1;
                    game.player2.health -= 1;
                    p2healthDisplay.text = "HP: " + game.player2.health;
                    p2comboDisplay.text = "x" + p2damageMultiplier;
                }
            }
            if (p2buttons[i].noteMiss)
            {
                p2buttons[i].noteMiss = false;
                p2multiplierTracker = 0;
                p2damageMultiplier = 1;
                p2comboDisplay.text = "x" + p2damageMultiplier;
                game.player2.health -= 1;
                p2healthDisplay.text = "HP: " + game.player2.health;
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
        if (!song.isPlaying)
        {
            if (game.player1.health > 0 && game.player2.health > 0)
            {
                if (game.player1.health > game.player2.health)
                {
                   //Solo(game.player1);
                }
                if (game.player2.health > game.player1.health)
                {
                    //Solo(game.player2);
                }
            }
        }
    }

    private void Solo(PlayerScript player)
    {
        player.gameObject.SetActive(false);
        SetUpWin();
        gameOverText.color = Color.red;
        gameOverText.text = player.tag + " SOLO!!!";
        if (soloNoteCounter <= 0)
        {
            gameOverText.color = Color.white;
            gameOverText.text = player.tag + " ROCKS!!!";
        }
        if (player.tag == "Player1")
        {
            foreach (ButtonController button in p1buttons)
            {
                if (Input.GetKeyDown(button.keyPressed))
                {
                    soloNoteCounter -= 1;
                }
            }
        }
        if (player.tag == "Player2")
        {
            foreach (ButtonController button in p2buttons)
            {
                if (Input.GetKeyDown(button.keyPressed))
                {
                    soloNoteCounter -= 1;
                }
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
