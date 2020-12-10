using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitCode : MonoBehaviour
{
    private Button quit;
    void Start()
    {
        quit = GetComponent<Button>();
        quit.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
