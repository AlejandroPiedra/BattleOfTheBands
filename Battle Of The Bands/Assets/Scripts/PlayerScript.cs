using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int health;
    public int damageStack = 1;
    public ButtonController[] buttons;
    public PlayerScript enemyPlayer;
    public Text HP;
    
    void Start()
    {
        HP.text = "HP: " + health;
    }

 
    void Update()
    {
        foreach (ButtonController button in buttons)
        {
            if (Input.GetKeyDown(button.keyPressed))
            {
                if (button.noteHit)
                {
                    enemyPlayer.health -= 1;
                    enemyPlayer.HP.text = "HP: " + enemyPlayer.health;
                }
                else
                {
                    health -= 1;
                    HP.text = "HP: " + health;
                }
            }
        }
    }
}
