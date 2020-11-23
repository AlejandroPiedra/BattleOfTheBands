using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public enum Band
    {
        NORTHAMERICA,
        SOUTHAMERICA,
        ASIA
    }

    public int health;
    public Band playerBand;
    public KeyCode button1;
    public KeyCode button2;
    public KeyCode button3;
    public KeyCode button4;

    public void SetBand(int num)
    {

        if (num == 0)
        {
            playerBand = Band.NORTHAMERICA;
        }
        if (num == 1)
        {
            playerBand = Band.SOUTHAMERICA;
        }
        if (num == 2)
        {
            playerBand = Band.ASIA;
        }
    }
}
