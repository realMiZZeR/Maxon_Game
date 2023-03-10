using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static bool isFullScreen = true;
    public AudioMixer am;
    Resolution[] rsl;
    List<string> resolutions;
    public Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {

    }

    /*
    public void Awake()
    {
        resolutions = new List<string>();
        rsl = Screen.resolutions;
        foreach(var i in rsl)
        {
            resolutions.Add(i.width + "x" + i.height);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);
    }
    */

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }
    public void AudioVolume(Slider slider)
    {
        
        am.SetFloat("masterVolume", slider.value);

    }
    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
;   }
    public void Resolution(int r)
    {
        Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
    }
}
