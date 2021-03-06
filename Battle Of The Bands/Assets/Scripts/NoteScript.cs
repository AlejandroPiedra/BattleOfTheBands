﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public bool pressed;
    public ButtonController button;
    private SpriteRenderer sprite;
    public GameObject hitEffect;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(button.keyPressed))
        {
            if (pressed)
            {
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Button")
        {
            pressed = true;
        }
        if(collision.tag == "ShowNote")
        {
            sprite.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Button")
        {
            pressed = false;
        }
    }
}
