﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playlist : MonoBehaviour
{

    Object[] myMusic;

    void Awake()
    {
        // Récuperer des fichiers dans notre dossier asset -> Resources -> Music tout les objets qui sont de type AudioClip.
        myMusic = Resources.LoadAll("Music", typeof(AudioClip));
        //Assigner la musique à une audio source, l'audiosoucre va permettre de jouer la premire musique d'ou le 0
        GetComponent<AudioSource>().clip = myMusic[0] as AudioClip;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Lancer la musique.
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        //Condition pour savoir quand la musique ne joue pas.
        if (!GetComponent<AudioSource>().isPlaying)
        {
            for(int i=0;i<myMusic.Length;i++)
            GetComponent<AudioSource>().clip = myMusic[i % myMusic.Length]  as AudioClip;
            GetComponent<AudioSource>().Play();
        }
    }
}