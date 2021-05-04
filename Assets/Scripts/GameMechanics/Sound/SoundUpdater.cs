using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChrisTutorials.Persistent;
using UnityEngine.UI;


public class SoundUpdater : MonoBehaviour
{
    public AudioManager.AudioChannel channel;
    public Text soundLevelsText;
    public string channelName;

    private Slider slider;

    //Assigns components.
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    //Adjusts sound levels
    public void updateSoundLevels() 
    {
        int sliderVal = (int)(slider.value * 100);

        AudioManager.Instance.SetVolume(channel, sliderVal);


        soundLevelsText.text = channelName + ": " + sliderVal + " / " + "100";

    }



    
   
}
