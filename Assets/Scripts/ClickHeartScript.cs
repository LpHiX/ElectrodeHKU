using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClickHeartScript : MonoBehaviour
{
    public HeartMenu heartMenu;
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(selectMethod);
    }

    private void selectMethod(SelectEnterEventArgs arg0)
    {
        heartMenu.startClicked();
    }
}
