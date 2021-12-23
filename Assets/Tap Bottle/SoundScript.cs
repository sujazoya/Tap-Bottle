using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundScript : MonoBehaviour
{
    public static SoundScript instance = null;
    private AudioSource audioSource;
    [SerializeField] Button musicButton;
    [SerializeField] GameObject musicOff;
    string musicKey = "Musicmusic";
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
       
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMusic();
        if (musicButton) { musicButton.onClick.AddListener(TogglePlayMusic); }
    }
    void TogglePlayMusic()
    {
        if (!PlayerPrefs.HasKey(musicKey))
        {
            PlayerPrefs.SetString(musicKey, musicKey);           
        }
        else
        {
            PlayerPrefs.DeleteKey(musicKey);
        }
        PlayMusic();
    }
    void PlayMusic()
    {
        if (!PlayerPrefs.HasKey(musicKey))
        {
            if (audioSource) { audioSource.Play(); }
            musicOff.SetActive(false);
        }
        else
        {
            if (audioSource) { audioSource.Stop(); }
            musicOff.SetActive(true);
        }
    }
}
