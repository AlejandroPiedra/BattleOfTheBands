using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    enum Band
    {
        NORTHAMERICA = 0,
        SOUTHAMERICA = 1,
        ASIA = 2
    }

    public ButtonController[] buttons;
    public PlayerScript enemyPlayer;
    public int health;
    public int damageMultiplier;
    public int multiplierTracker;
    public int[] multiplierArray;
    public Text healthDisplay;
    public Text comboDisplay;
    Band myBand;
    
    void Start()
    {
        healthDisplay.text = "HP: " + health;
        damageMultiplier = 1;
    }

 
    void Update()
    {
        foreach (ButtonController button in buttons)
        {
            if (Input.GetKeyDown(button.keyPressed))
            {
                if (button.noteHit)
                {
                    if(damageMultiplier - 1 < multiplierArray.Length)
                    {
                        multiplierTracker++;
                        if (multiplierArray[damageMultiplier - 1] <= multiplierTracker)
                        {
                            multiplierTracker = 0;
                            damageMultiplier++;
                            comboDisplay.text = "x" + damageMultiplier;
                        }
                    }
                    enemyPlayer.health -= 1 * damageMultiplier;
                    enemyPlayer.healthDisplay.text = "HP: " + enemyPlayer.health;
                    button.noteHit = false;
                }
                else
                {
                    multiplierTracker = 0;
                    damageMultiplier = 1;
                    health -= 1;
                    healthDisplay.text = "HP: " + health;
                    comboDisplay.text = "x" + damageMultiplier;
                }
            }
            if (button.noteMiss)
            {
                button.noteMiss = false;
                multiplierTracker = 0;
                damageMultiplier = 1;
                comboDisplay.text = "x" + damageMultiplier;
                health -= 1;
                healthDisplay.text = "HP: " + health;
            }
        }
    }

    public void SetBand(int num)
    {
        if(num == 0)
        {
            myBand = Band.NORTHAMERICA;
        }
        if(num == 1)
        {
            myBand = Band.SOUTHAMERICA;
        }
        if(num == 2)
        {
            myBand = Band.ASIA;
        }
    }
}
