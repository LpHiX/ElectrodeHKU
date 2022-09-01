using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ECGScript : MonoBehaviour
{
    public Slider waveSlider;
    public Slider playbackSlider;
    public Slider speedSlider;
    public MeshRenderer chestRenderer;
    public MeshRenderer limbRenderer;
    public Material originalMat;
    public Material animationMat;
    public Texture chestPTexture;
    public Texture chestQTexture;
    public Texture chestRTexture;
    public Texture chestSTexture;
    public Texture chestTTexture;

    private RectTransform rectTransform;

    public bool loopSectionOnly = true;
    public bool animationPlaying = true;
    public bool animationLooping = true;
    public int waveNumber = 1;
    public int progress = 0;
    public int timeLeft = 0;
    public int maxFrames = 10;
    public int speed = 5;
    public void FixedUpdate()
    {
        if (timeLeft < 1)
        {
            if (!animationPlaying)
            {
                return;
            }
            if (progress >= maxFrames)
            {
                if (loopSectionOnly)
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
                else
                {
                    if (waveNumber < 5)
                    {
                        selectWave(waveNumber + 1);
                        waveSlider.SetValueWithoutNotify(waveNumber);
                    }
                    else
                    {
                        if (animationLooping)
                        {
                            selectWave(1);
                            waveSlider.SetValueWithoutNotify(waveNumber);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            playbackSlider.SetValueWithoutNotify(progress);
            limbRenderer.material.mainTextureOffset = new Vector2(0, (float)progress / maxFrames);
            timeLeft += (int)Mathf.Round(40 / (float) speed);
            progress += 1;
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
        LeanTween.scale(rectTransform, new Vector3(0.5f, .5f, 1), 0.5f).setEaseOutBack();
        limbRenderer.material = animationMat;
        selectWave(1);
    }
    public void selectWave(int wave)
    {
        switch (wave){
            case 1:
                limbRenderer.material.mainTexture = chestPTexture;
                maxFrames = 12;
                break;
            case 2:
                limbRenderer.material.mainTexture = chestQTexture;
                maxFrames = 5;
                break;
            case 3:
                limbRenderer.material.mainTexture = chestRTexture;
                maxFrames = 5;
                break;
            case 4:
                limbRenderer.material.mainTexture = chestSTexture;
                maxFrames = 3;
                break;
            case 5:
                limbRenderer.material.mainTexture = chestTTexture;
                maxFrames = 7;
                break;
            default:
                Debug.Log("Wave letter doesn't exist");
                break;
        }
        waveNumber = wave;
        recalculateConstants();
    }
    public void WaveValueChanged()
    {
        selectWave((int)waveSlider.value);
        limbRenderer.material.mainTextureOffset = new Vector2(0, (float)progress / maxFrames);
        timeLeft += (int)Mathf.Round(40 / (float)speed);
    }
    private void recalculateConstants()
    {
        playbackSlider.SetValueWithoutNotify(0);
        playbackSlider.maxValue = maxFrames - 1;
        progress = 0;
        limbRenderer.material.mainTextureScale = new Vector2(1, 1 / (float) maxFrames);
    }
    public void Hide()
    {
        limbRenderer.material = originalMat;
        rectTransform = GetComponent<RectTransform>();
        LeanTween.scale(rectTransform, new Vector3(0, 0, 1), 0.5f).setEaseOutBack();
    }
    public void PlaybackValueChanged()
    {
        progress = (int)playbackSlider.value;
        limbRenderer.material.mainTextureOffset = new Vector2(0, (float)progress / maxFrames);
    }
    public void SpeedValueChanged()
    {
        speed = (int)speedSlider.value;
    }
    public void playClicked(Toggle change)
    {
        animationPlaying = change.isOn;
    }
    public void loopSectionClick(Toggle change)
    {
        loopSectionOnly = change.isOn;
    }
    public void loopClicked(Toggle change)
    {
        animationLooping = change.isOn;
    }
}
