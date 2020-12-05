using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameScriptableObject game;
    public AudioSource song;
    public bool startPlaying;
    public bool gameOver;
    public NoteScroller noteScroller;
    public RectTransform gameOverPanel;
    public Text gameOverText;
    public Button gameOverButton;
    public ButtonController[] p1buttons;
    public ButtonController[] p2buttons;
    public PlayerScript player1;
    public PlayerScript player2;
    public Image P1healthbar;
    public Image P2healthbar;

    public int p1damageMultiplier;
    public int p1multiplierTracker;
    public int[] p1multiplierArray;
    public Text p1comboDisplay;
    public int p2damageMultiplier;
    public int p2multiplierTracker;
    public int[] p2multiplierArray;
    public Text p2comboDisplay;


    void Start()
    {
        game.player1 = player1;
        game.player2 = player2;
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

        if (!gameOver)
        {
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
                        P2healthbar.fillAmount = game.player2.health / 100f;
                        p1buttons[i].noteHit = false;
                    }
                    else
                    {
                        p1multiplierTracker = 0;
                        p1damageMultiplier = 1;
                        game.player1.health -= 1;
                        P1healthbar.fillAmount = game.player1.health / 100f;
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
                    P1healthbar.fillAmount = game.player1.health / 100f;
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
                        P1healthbar.fillAmount = game.player1.health / 100f;
                        p2buttons[i].noteHit = false;
                    }
                    else
                    {
                        p2multiplierTracker = 0;
                        p2damageMultiplier = 1;
                        game.player2.health -= 1;
                        P2healthbar.fillAmount = game.player2.health / 100f;
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
                    P2healthbar.fillAmount = game.player2.health / 100f;
                }
            }
        }
        

        //Check Win/Loss
        if (game.player1.health <= 0)
        {
            gameOverText.color = Color.white;
            gameOverText.text = "Player 2 Rocks!!!";
            gameOverButton.gameObject.SetActive(true);
            SetUpWin();
        }
        if (game.player2.health <= 0)
        {
            gameOverText.color = Color.white;
            gameOverButton.gameObject.SetActive(true);
            gameOverText.text = "Player 1 Rocks!!!";
            SetUpWin();
        }

        //Check For a Solo
        if (!song.isPlaying)
        {
            if (game.player1.health > 0 && game.player2.health > 0)
            {
                if (game.player1.health > game.player2.health)
                {
                    gameOver = true;
                    Solo(game.player1);
                }
                if (game.player2.health > game.player1.health)
                {
                    gameOver = true;
                    Solo(game.player2);
                }
            }
        }
    }

    private void Solo(PlayerScript player)
    {
        SetUpWin();
        gameOverText.color = Color.red;
        gameOverText.text = player.tag + " SOLO THEM!!!";
        if (player.tag == "Player1")
        {
            foreach (ButtonController button in p1buttons)
            {
                if (Input.GetKeyDown(button.keyPressed))
                {
                    game.player2.health -= 1;
                    P2healthbar.fillAmount = game.player2.health / 100f;
                }
            }
        }

        if (player.tag == "Player2")
        {
            foreach (ButtonController button in p2buttons)
            {
                if (Input.GetKeyDown(button.keyPressed))
                {
                    game.player1.health -= 1;
                    P1healthbar.fillAmount = game.player1.health / 100f;
                }
            }
        }
    }

    private void SetUpWin()
    {
        gameOver = true;
        song.Stop();
        noteScroller.startScroll = false;
        gameOverPanel.gameObject.SetActive(true);
    }
}
