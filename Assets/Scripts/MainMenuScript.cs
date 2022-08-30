using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void electrodeScene()
    {
        SceneManager.LoadScene("ElectrodeScene");
    }
    public void heartCurrentScene()
    {
        SceneManager.LoadScene("HeartCurrentScene");
    }
}
