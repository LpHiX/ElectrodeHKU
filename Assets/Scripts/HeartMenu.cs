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

    public void selectLimb()
    {
        hide0();
        LeanTween.moveY(chestHeart, -1, .5f).setEase(LeanTweenType.easeInBack);
        LeanTween.moveX(limbHeart, 0, .5f).setEase(LeanTweenType.easeInBack);
    }
    public void selectChest()
    {
        hide0();
        LeanTween.moveY(limbHeart, -1, .5f).setEase(LeanTweenType.easeInBack);
        LeanTween.moveX(chestHeart, 0, .5f).setEase(LeanTweenType.easeInBack);
    }
    private void hide0()
    {
        LeanTween.moveY(fullHeart, -1, .5f).setEase(LeanTweenType.easeInBack).setOnComplete(chestSelected);
        LeanTween.scale(limbButton, new Vector3(.0f, .0f), 0.5f).setEase(LeanTweenType.easeInBack);
        LeanTween.scale(chestButton, new Vector3(.0f, .0f), 0.5f).setEase(LeanTweenType.easeInBack);
        LeanTween.scale(panelTransform, new Vector3(.5f, .5f), 0.5f).setEase(LeanTweenType.easeInBack);
        LeanTween.moveY(panelTransform, -78, .5f).setEaseInBack();

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
    public void ECGChestSelected(int num)
    {
        ecgDisplay.sprite = chestSprites[num];
        LeanTween.scale(limbMenu, new Vector3(0.5f, 0.5f, 1), 0.5f).setEaseOutBack().setOnComplete(ECGSelected);
    }
    public void ECGLimbSelected(int num)
    {
        ecgDisplay.sprite = limbSprites[num];
        LeanTween.scale(chestMenu, new Vector3(0.5f, 0.5f, 1), .5f).setEaseOutBack().setOnComplete(ECGSelected);
    }
    private void ECGSelected()
    {
        LeanTween.scale(panelTransform, new Vector3(0, 0), 0.5f).setEase(LeanTweenType.easeInBack);
        panelTransform.gameObject.SetActive(false);
        ecgDisplay.gameObject.SetActive(true);
        LeanTween.scale(ecgDisplay.rectTransform, new Vector3(1, 1, 1), 0.5f).setEaseOutBack();
        chestMenu.gameObject.SetActive(false);
        limbMenu.gameObject.SetActive(false);
    }
}