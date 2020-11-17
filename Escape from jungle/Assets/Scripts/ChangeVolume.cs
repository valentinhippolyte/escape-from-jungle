using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVolume : MonoBehaviour
{
    //modificateur de volume
    public AudioSource audioSource;
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
