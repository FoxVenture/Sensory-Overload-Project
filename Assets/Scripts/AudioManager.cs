using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] UIsounds;
    public AudioManager instance;

    void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    public void Play(int nr)
    {
        Sound s = sounds[nr];
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
        }
        s.source.Play();

    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, s => s.name == name);
        if (s == null)
        { 
            Debug.LogWarning("Sound: " + name + "not found!");
        }
        s.source.Play();
    }
    public void PlayUI()
    {
        Sound s = Array.Find(UIsounds, s => s.name == "UISound");
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
        }
        s.source.Play();
    }

}
