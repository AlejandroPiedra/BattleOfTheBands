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
        if (game.player1.playerBand == PlayerScript.Band.ASIA && game.player2.playerBand == PlayerScript.Band.NORTHAMERICA)
        {
            //Set Song
            SceneManager.LoadScene(5);
        }
        if (game.player1.playerBand == PlayerScript.Band.ASIA && game.player2.playerBand == PlayerScript.Band.SOUTHAMERICA)
        {
            SceneManager.LoadScene(6);
        }
        if (game.player1.playerBand == PlayerScript.Band.NORTHAMERICA && game.player2.playerBand == PlayerScript.Band.ASIA)
        {
            SceneManager.LoadScene(7);
        }
        if (game.player1.playerBand == PlayerScript.Band.NORTHAMERICA && game.player2.playerBand == PlayerScript.Band.SOUTHAMERICA)
        {
            SceneManager.LoadScene(4);
        }
        if (game.player1.playerBand == PlayerScript.Band.SOUTHAMERICA && game.player2.playerBand == PlayerScript.Band.ASIA)
        {
            SceneManager.LoadScene(8);
        }
        if (game.player1.playerBand == PlayerScript.Band.NORTHAMERICA && game.player2.playerBand == PlayerScript.Band.NORTHAMERICA)
        {
            SceneManager.LoadScene(9);
        }
    }

    public void SetUpBand(int num)
    {

    }
}
