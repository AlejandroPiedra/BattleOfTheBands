using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer buttonSprite;
    private bool noteIsColliding;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public KeyCode keyPressed;

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

        //Checks if note is  hit or miss
        if (noteIsColliding && Input.GetKeyDown(keyPressed))
        {
            Debug.Log("Note Hit");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Note")
        {
            noteIsColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Note")
        {
            noteIsColliding = false;
        }
    }

}
