using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ECGScript : MonoBehaviour
{
    public Slider playbackSlider;
    public Slider speedSlider;
    public MeshRenderer chestRenderer;
    public MeshRenderer limbRenderer;
    public Texture chestPTexture;

    private RectTransform rectTransform;

    private bool animationPlaying = true;
    private bool animationLooping = true;
    private int progress = 0;
    private int timeLeft = 0;
    private int maxFrames = 10;
    private int speed = 5;
    public void FixedUpdate()
    {
        if (!animationPlaying)
        {
            return;
        }
        if (progress >= 1)
        {
            if (animationLooping)
            {
                progress = 0;
            }
            else
            {
                return;
            }
        }

        if(timeLeft < 1)
        {
            progress += 1;
            limbRenderer.material.mainTextureOffset = new Vector2(0, progress / maxFrames);
            timeLeft += (int)Mathf.Round(20 / speed);
        }
        timeLeft--;
    }
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void Show(bool chest, int num)
    {
        rectTransform = GetComponent<RectTransform>();
        LeanTween.scale(rectTransform, new Vector3(1, 1, 1), 0.5f).setEaseOutBack();
        limbRenderer.material.mainTexture = chestPTexture;
    }
    public void Hide()
    {
        rectTransform = GetComponent<RectTransform>();
        LeanTween.scale(rectTransform, new Vector3(0, 0, 1), 0.5f).setEaseOutBack();
    }
    public void PlaybackValueChanged()
    {
        progress = (int)playbackSlider.value;
    }
    public void SpeedValueChanged()
    {
        speed = (int)speedSlider.value;
    }
    public void playClicked(Toggle change)
    {
        animationPlaying = change.isOn;
    }
    public void loopClicked(Toggle change)
    {
        animationLooping = change.isOn;
    }
}
