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
    public Image ecgDisplay;
    public Sprite[] chestSprites;
    public Sprite[] limbSprites;
    public RectTransform toSelectLeadButton;
    public RectTransform toChestSelectButton;
    public RectTransform toLimbSelectButton;

    public void startPosition()
    {
        LeanTween.moveY(fullHeart, 0.5f, .5f).setEase(LeanTweenType.easeInBack).setOnComplete(chestSelected).setOnComplete(hideTillStart);
        LeanTween.scale(limbButton, new Vector3(1.0f, 1.0f, 1), 0.5f).setEase(LeanTweenType.easeInBack);
        LeanTween.scale(chestButton, new Vector3(1.0f, 1.0f, 1), 0.5f).setEase(LeanTweenType.easeInBack);
        LeanTween.scale(panelTransform, new Vector3(1f, .1f, 1), 0.5f).setEase(LeanTweenType.easeInBack);
        LeanTween.moveY(panelTransform, -0, .5f).setEaseInBack();
        LeanTween.move(chestHeart, new Vector3(-1.3f, 1f, 2), .5f).setEaseInBack();
        LeanTween.move(limbHeart, new Vector3(1.2f, 1f, 2), .5f).setEaseInBack();
        LeanTween.scale(limbMenu, new Vector3(0.0f, 0.0f, 1), 0.5f).setEaseOutBack();
        LeanTween.scale(chestMenu, new Vector3(0.0f, 0.0f, 1), .5f).setEaseOutBack();
        LeanTween.scale(toSelectLeadButton, new Vector3(0.0f, 0.0f, 1), .5f).setEaseOutBack();
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
        LeanTween.moveY(chestHeart, -1, .5f).setEase(LeanTweenType.easeInBack).setOnComplete(limbSelected);
        LeanTween.moveX(limbHeart, 0, .5f).setEase(LeanTweenType.easeInBack);
    }
    public void selectChest()
    {
        hide0();
        LeanTween.moveY(limbHeart, -1, .5f).setEase(LeanTweenType.easeInBack).setOnComplete(chestSelected);
        LeanTween.move(chestHeart, new Vector3(-0.7f, 1.3535f, 2f), .5f).setEase(LeanTweenType.easeInBack);
    }
    private void hide0()
    {
        LeanTween.moveY(fullHeart, -1, .5f).setEase(LeanTweenType.easeInBack);
        LeanTween.scale(limbButton, new Vector3(.0f, .0f, 1), 0.5f).setEase(LeanTweenType.easeInBack);
        LeanTween.scale(chestButton, new Vector3(.0f, .0f, 1), 0.5f).setEase(LeanTweenType.easeInBack);
        LeanTween.scale(panelTransform, new Vector3(.5f, .5f, 1), 0.5f).setEase(LeanTweenType.easeInBack);
        LeanTween.moveY(panelTransform, -78, .5f).setEaseInBack();
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
    }
    private void hideECGDisplay()
    {
        ecgDisplay.gameObject.SetActive(false);
        toLimbSelectButton.gameObject.SetActive(false);
        toChestSelectButton.gameObject.SetActive(false);
    }
    public void ECGChestSelected(int num)
    {
        LeanTween.scale(panelTransform, new Vector3(0, 0), 0.5f).setEase(LeanTweenType.easeInBack);
        ecgDisplay.gameObject.SetActive(true);
        LeanTween.scale(ecgDisplay.rectTransform, new Vector3(1, 1, 1), 0.5f).setEaseOutBack();
        LeanTween.scale(toSelectLeadButton, new Vector3(0, 0, 1), .5f).setEaseOutBack();

        ecgDisplay.sprite = chestSprites[num];
        LeanTween.scale(chestMenu, new Vector3(0f, 0f, 1), 0.5f).setEaseOutBack().setOnComplete(ECGChestSelectedAfter);
    }
    public void ECGLimbSelected(int num)
    {
        LeanTween.scale(panelTransform, new Vector3(0, 0), 0.5f).setEase(LeanTweenType.easeInBack);
        ecgDisplay.gameObject.SetActive(true);
        LeanTween.scale(ecgDisplay.rectTransform, new Vector3(1, 1, 1), 0.5f).setEaseOutBack();
        LeanTween.scale(toSelectLeadButton, new Vector3(0, 0, 1), .5f).setEaseOutBack();

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