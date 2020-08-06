﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    private int pressButtonType;


    public GameObject PauseWindow;
    public Animation PauseWindowAnimation;

    private static bool isPauseGame = false;
    public static bool IsPauseGame { get { return isPauseGame; } }

    private bool isPressButton = false;

    // Start is called before the first frame update
    void Start()
    {
        if (PauseWindow == null)
        {
            PauseWindow = GameObject.Find("PauseGameWindow");
            PauseWindowAnimation = PauseWindow.GetComponent<Animation>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseWindow == null)
            return;
        if(Input.GetKeyDown(KeyCode.Escape) && !isPauseGame)
        {
            PauseWindow.SetActive(true);
            isPauseGame = true;
        }
        else
        {
            if(isPressButton)
            {
                if (!PauseWindowAnimation.isPlaying)
                {
                    PauseWindow.SetActive(false);
                    switch (pressButtonType)
                    {
                        case 0:
                            break;
                        case 1:
                            SceneManager.LoadScene(0);
                            break;
                        case 2:
                            Application.Quit();
                            break;
                    }
                    isPauseGame = false;
                }
            }
        }
    }

    public void PressPauseWinowReturnGameButton()
    {
        PressButton();
        pressButtonType = 0;
    }

    public void PressPauseWinowReturnStartPageButton()
    {
        PressButton();
        pressButtonType = 1;
    }

    public void PressPauseWindowExitButton()
    {
        PressButton();
        pressButtonType = 2;
    }

    private void PressButton()
    {
        Debug.Log("PressButton");
        isPressButton = true;

        PauseWindowAnimation["PauseWindowShowUp"].time = PauseWindowAnimation["PauseWindowShowUp"].clip.length;
        PauseWindowAnimation["PauseWindowShowUp"].speed = -1f;
        PauseWindowAnimation.Play("PauseWindowShowUp");
    }
}
