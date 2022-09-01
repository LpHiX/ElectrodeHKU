using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartMenu : MonoBehaviour
{
    public RectTransform panelTransform;
    public RectTransform limbButton;
    public RectTransform chestButton;
    public GameObject fullHeart;
    public GameObject limbHeart;
    public GameObject chestHeart;
    public RectTransform chestMenu;
    public RectTransform limbMenu;
    public ECGScript ecgScreen;
    public Image ecgDisplay;
    public Sprite[] chestSprites;
    public Sprite[] limbSprites;
    public RectTransform toSelectLeadButton;
    public RectTransform toChestSelectButton;
    public RectTransform toLimbSelectButton;
    private bool clicked = false;
    private void Start()
    {
        fullHeart.transform.position = new Vector3(-0.0346f, 1.343f, 2.02f);
        fullHeart.transform.localScale = new Vector3(0.13f, 0.13f, 0.13f);
        limbButton.transform.localScale = new Vector3(0, 0, 0);
        chestButton.transform.localScale = new Vector3(0, 0, 0);
        panelTransform.localScale = new Vector3(0, 0, 0);
        limbHeart.transform.eulerAngles = new Vector3(305.817841f, 144.439285f, 337.68396f);
        chestHeart.transform.eulerAngles = new Vector3(305.0065f, 159.553055f, 333.873016f);

        limbHeart.transform.position = new Vector3(1.5f, 0.5f, 2);
        chestHeart.transform.position = new Vector3(1.5f, 0.5f, 2);
        limbHeart.transform.localScale = new Vector3(0.013f, 0.013f, 0.013f);
        chestHeart.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        limbHeart.SetActive(false);
        chestHeart.SetActive(false);
    }
    public void startClicked()
    {
        if (!clicked)
        {
            startPosition();
            clicked = true;
        }
    }
    public void startPosition()
    {
        limbHeart.SetActive(false);
        chestHeart.SetActive(false);
        LeanTween.scale(gameObject, new Vector3(0.002f, 0.002f, 0.002f), 1.5f).setEaseOutBack();
        LeanTween.scale(fullHeart, new Vector3(1.3f, 1.3f, 1.3f), 1.5f).setOnComplete(hideTillStart).setEaseOutBack();
        LeanTween.move(fullHeart, new Vector3(1.5f, 0.5f, 2), 1.5f).setEaseOutBack();
        
        //LeanTween.move(chestHeart, new Vector3(-1.3f, 1f, 2), .5f).setEaseInBack();
        //LeanTween.move(limbHeart, new Vector3(1.2f, 1f, 2), .5f).setEaseInBack();

        LeanTween.scale(limbButton, new Vector3(1.0f, 1.0f, 1), 0.5f).setEase(LeanTweenType.easeInBack);
        LeanTween.scale(chestButton, new Vector3(1.0f, 1.0f, 1), 0.5f).setEase(LeanTweenType.easeInBack);
        LeanTween.scale(panelTransform, new Vector3(1f, .1f, 1), 0.5f).setEase(LeanTweenType.easeInBack);
        LeanTween.scale(limbMenu, new Vector3(0.0f, 0.0f, 1), 0.5f).setEaseOutBack();
        LeanTween.scale(chestMenu, new Vector3(0.0f, 0.0f, 1), 0.5f).setEaseOutBack();
        LeanTween.scale(toSelectLeadButton, new Vector3(0.0f, 0.0f, 1), 0.5f).setEaseOutBack();
    }
    public void hideTillStart()
    {
        chestMenu.gameObject.SetActive(false);
        limbMenu.gameObject.SetActive(false);
        toSelectLeadButton.gameObject.SetActive(false);
    }

    public void selectLimb()
    {
        hide0();
        LeanTween.scale(fullHeart, new Vector3(0, 0, 0), .5f).setEaseOutBack().setOnComplete(limbSelected);
        limbHeart.SetActive(true);
    }
    public void selectChest()
    {
        hide0();
        LeanTween.scale(fullHeart, new Vector3(0, 0, 0), .5f).setEaseOutBack().setOnComplete(chestSelected);
        chestHeart.SetActive(true);
    }
    private void hide0()
    {
        LeanTween.scale(limbButton, new Vector3(.0f, .0f, 1), 0.5f).setEase(LeanTweenType.easeInBack);
        LeanTween.scale(chestButton, new Vector3(.0f, .0f, 1), 0.5f).setEase(LeanTweenType.easeInBack);
        LeanTween.scale(panelTransform, new Vector3(.5f, .5f, 1), 0.5f).setEase(LeanTweenType.easeInBack);
        toSelectLeadButton.gameObject.SetActive(true);
        LeanTween.scale(toSelectLeadButton, new Vector3(1, 1, 1), .5f).setEaseOutBack();

    }
    public void limbSelected()
    {
        limbMenu.gameObject.SetActive(true);
        LeanTween.scale(limbMenu, new Vector3(0.5f, 0.5f, 1), 0.5f).setEaseOutBack();
    }
    public void chestSelected()
    {
        chestMenu.gameObject.SetActive(true);
        LeanTween.scale(chestMenu, new Vector3(0.5f, 0.5f, 1), .5f).setEaseOutBack();
    }
    public void returnToLimb()
    {
        panelTransform.gameObject.SetActive(true);
        LeanTween.scale(panelTransform, new Vector3(0.5f, 0.5f), 0.5f).setEaseOutBack();
        limbMenu.gameObject.SetActive(true);
        LeanTween.scale(limbMenu, new Vector3(0.5f, 0.5f, 1), 0.5f).setEaseOutBack();
        LeanTween.scale(ecgDisplay.rectTransform, new Vector3(0, 0, 1), 0.5f).setEaseOutBack().setOnComplete(hideECGDisplay);
        toSelectLeadButton.gameObject.SetActive(true);
        LeanTween.scale(toSelectLeadButton, new Vector3(1, 1, 1), .5f).setEaseOutBack();
        LeanTween.scale(toLimbSelectButton, new Vector3(0, 0, 1), .5f).setEaseOutBack();
        ecgScreen.Hide();
    }
    public void returnToChest()
    {
        panelTransform.gameObject.SetActive(true);
        LeanTween.scale(panelTransform, new Vector3(0.5f, 0.5f), 0.5f).setEaseOutBack();
        chestMenu.gameObject.SetActive(true);
        LeanTween.scale(chestMenu, new Vector3(0.5f, 0.5f, 1), 0.5f).setEaseOutBack();
        LeanTween.scale(ecgDisplay.rectTransform, new Vector3(0, 0, 1), 0.5f).setEaseOutBack().setOnComplete(hideECGDisplay);
        toSelectLeadButton.gameObject.SetActive(true);
        LeanTween.scale(toSelectLeadButton, new Vector3(1, 1, 1), .5f).setEaseOutBack();
        LeanTween.scale(toChestSelectButton, new Vector3(0, 0, 1), .5f).setEaseOutBack();
        ecgScreen.Hide();
    }
    private void hideECGDisplay()
    {
        toLimbSelectButton.gameObject.SetActive(false);
        toChestSelectButton.gameObject.SetActive(false);
        ecgScreen.gameObject.SetActive(false);
    }
    public void ECGChestSelected(int num)
    {
        LeanTween.scale(panelTransform, new Vector3(0, 0), 0.5f).setEase(LeanTweenType.easeInBack);
        LeanTween.scale(toSelectLeadButton, new Vector3(0, 0, 1), .5f).setEaseOutBack();

        ecgScreen.gameObject.SetActive(true);
        ecgScreen.Show(true, num);
        ecgDisplay.sprite = chestSprites[num];
        
        LeanTween.scale(chestMenu, new Vector3(0f, 0f, 1), 0.5f).setEaseOutBack().setOnComplete(ECGChestSelectedAfter);
    }
    public void ECGLimbSelected(int num)
    {
        LeanTween.scale(panelTransform, new Vector3(0, 0), 0.5f).setEase(LeanTweenType.easeInBack);
        LeanTween.scale(ecgDisplay.rectTransform, new Vector3(1, 1, 1), 0.5f).setEaseOutBack();
        LeanTween.scale(toSelectLeadButton, new Vector3(0, 0, 1), .5f).setEaseOutBack();

        ecgScreen.gameObject.SetActive(true);
        ecgScreen.Show(false, num);
        ecgDisplay.sprite = limbSprites[num];
       
        LeanTween.scale(limbMenu, new Vector3(0f, 0f, 1), .5f).setEaseOutBack().setOnComplete(ECGLimbSelectedAfter);
    }
    private void ECGLimbSelectedAfter()
    {
        panelTransform.gameObject.SetActive(false);
        chestMenu.gameObject.SetActive(false);
        limbMenu.gameObject.SetActive(false);
        toLimbSelectButton.gameObject.SetActive(true);
        LeanTween.scale(toLimbSelectButton, new Vector3(1, 1, 1), .5f).setEaseOutBack();
    }
    private void ECGChestSelectedAfter()
    {
        panelTransform.gameObject.SetActive(false);
        chestMenu.gameObject.SetActive(false);
        limbMenu.gameObject.SetActive(false);
        toChestSelectButton.gameObject.SetActive(true);
        LeanTween.scale(toChestSelectButton, new Vector3(1, 1, 1), .5f).setEaseOutBack();
    }
}