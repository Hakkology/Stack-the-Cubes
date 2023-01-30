using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        ChangeVolume();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
