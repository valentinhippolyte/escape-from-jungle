using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public void SetVolume(float volume)
    {
        //Le slider gère le volume 
        audioSource.volume = volume;
    }
    
    public void SetFullScreen(bool isFullScreen)
    {
        //Lorsque la case est cochée, le jeu s'affiche en plein écran 
        Screen.fullScreen = isFullScreen;
    }
}
