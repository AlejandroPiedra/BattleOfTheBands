using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BandManager : MonoBehaviour
{
    public GameScriptableObject game;
    public PlayerScript p1;
    public PlayerScript p2;
    public Text selectText;

    void Start()
    {
        game.player1 = p1;
        game.player2 = p2;
        selectText.text = "P1 Chose A Band";
    }

    void Update()
    {
        if (game.player1.playerBand != PlayerScript.Band.NONE && game.player2.playerBand == PlayerScript.Band.NONE)
        {
            selectText.text = "P2 Chose A Band";
        }

        if (game.player1.playerBand == PlayerScript.Band.ASIA && game.player2.playerBand == PlayerScript.Band.NORTHAMERICA)
        {
            
            SceneManager.LoadScene(4);
        }
        else if (game.player1.playerBand == PlayerScript.Band.ASIA && game.player2.playerBand == PlayerScript.Band.SOUTHAMERICA)
        {
            SceneManager.LoadScene(5);
        }
        else if (game.player1.playerBand == PlayerScript.Band.NORTHAMERICA && game.player2.playerBand == PlayerScript.Band.ASIA)
        {
            SceneManager.LoadScene(6);
        }
        else if (game.player1.playerBand == PlayerScript.Band.NORTHAMERICA && game.player2.playerBand == PlayerScript.Band.SOUTHAMERICA)
        {
            SceneManager.LoadScene(3);
        }
        else if (game.player1.playerBand == PlayerScript.Band.SOUTHAMERICA && game.player2.playerBand == PlayerScript.Band.ASIA)
        {
            SceneManager.LoadScene(7);
        }
        else if (game.player1.playerBand == PlayerScript.Band.SOUTHAMERICA && game.player2.playerBand == PlayerScript.Band.NORTHAMERICA)
        {
            SceneManager.LoadScene(8);
        }
    }

    public void SetUpBand(int num)
    {
        if (game.player1.playerBand == PlayerScript.Band.NONE)
        {
            game.player1.SetBand(num);
        }
        else if (game.player1.playerBand != PlayerScript.Band.NONE && game.player2.playerBand == PlayerScript.Band.NONE)
        {
            game.player2.SetBand(num);
        }
    }
}
