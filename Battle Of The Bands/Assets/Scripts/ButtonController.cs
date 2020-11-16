using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer buttonSprite;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public KeyCode keyPressed;
    public bool noteHit;
    public bool noteMiss;

    void Start()
    {
        buttonSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Changes button sprite
        if (Input.GetKeyDown(keyPressed))
        {
            buttonSprite.sprite = pressedImage;
        }
        if (Input.GetKeyUp(keyPressed))
        {
            buttonSprite.sprite = defaultImage;
        }
    }

    /* When the note exits the collider and its active, Subtract 1 hp from the player and deactivate the note (This means the note was not hit during the collision window)
     *  else
     *  When the note exits the collider and its not active, Subtract 1 hp from the other player (This means the note was hit during the collision window)
     */


    private void OnTriggerEnter2D(Collider2D collision)
    {
        noteHit = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.activeSelf)
        {
            noteHit = true;
        }
        else
        {
            noteHit = false;
            noteMiss = true;
            collision.gameObject.SetActive(false);
        }
    }
}
