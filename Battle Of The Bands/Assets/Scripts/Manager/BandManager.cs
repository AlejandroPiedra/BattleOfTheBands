using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    }

    void Update()
    {
            
    }

    public void ChooseBandP1(int band)
    {
        game.player1.SetBand(band);
        gameObject.SetActive(false);
    }

    public void ChooseBandP2(int band)
    {

    }
}
