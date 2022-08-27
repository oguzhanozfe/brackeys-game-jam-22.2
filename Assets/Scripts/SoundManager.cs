using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            slider.value = PlayerPrefs.GetFloat("volume", 1);
            Load();
        }else
        {
            Load();
        }

    }

    public void SetVolume()
    {
        AudioListener.volume = slider.value;
        Save();
    }

    private void Load()
    {
        slider.value = PlayerPrefs.GetFloat("volume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("volume", slider.value);
    }
}
