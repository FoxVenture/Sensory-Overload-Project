using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioManager instance;

    public bool MouseScroll, PenTapping, PenClickIn, KeyboardTyping, SmartphoneCall = false;

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

    private void Update()
    {
        if (MouseScroll == true) Play("Mouse Scroll");       
        if (PenTapping == true) Play("Pen Tapping");
        if (PenClickIn == true) Play("Pen Click In");
        if (KeyboardTyping == true) Play("Keyboard Typing");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, s => s.name == name);
        if (s.source.isPlaying) return;
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
            s.source.Play();
        
    }

}
