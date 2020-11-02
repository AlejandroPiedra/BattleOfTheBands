using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public bool pressed;
    public KeyCode keyToPress;

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (pressed)
            {
                gameObject.SetActive(false);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Button")
        {
            pressed = true;
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
