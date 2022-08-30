using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;

public class WristMenuScript : MonoBehaviour
{
    public GameObject menuCanvas;
    public InputActionReference menuButton;
    private bool menuShown = false;
    // Start is called before the first frame update
    void Start()
    {
        if (menuCanvas.activeSelf)
        {
            menuCanvas.SetActive(false);
        }
        menuButton.action.started += toggleMenu;
    }

    public void toggleMenu(InputAction.CallbackContext obj)
    {
        toggleMenu();
    }
    public void toggleMenu()
    {
        menuShown = !menuShown;
        menuCanvas.SetActive(menuShown);
    }
    public void goToMainScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        menuButton.action.started -= toggleMenu;
    }
}
