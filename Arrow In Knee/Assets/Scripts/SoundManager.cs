using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundOn;
    [SerializeField] Image soundOff;
    private bool mute = false;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("mute"))
        {
            PlayerPrefs.SetInt("mute", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = mute;
    }

    public void OnButtonPress()
    {
        if(mute == false)
        {
            mute = true;
            AudioListener.pause = true;
        }
        else
        {
            mute = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if(mute == false)
        {
            soundOn.enabled = true;
            soundOff.enabled = false;
        }
        else
        {
            soundOn.enabled = false;
            soundOff.enabled = true;
        }
    }

    private void Load()
    {
        mute = PlayerPrefs.GetInt("mute") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("mute", mute ? 1 : 0);
    }

}
