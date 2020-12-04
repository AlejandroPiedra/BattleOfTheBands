using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public enum Band
    {
        NONE,
        NORTHAMERICA,
        SOUTHAMERICA,
        ASIA
    }

    public float health;
    public Band playerBand = Band.NONE;

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
