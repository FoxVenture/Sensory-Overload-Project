using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioManager instance;

    public bool MouseScroll, PenTapping, PenClickIn, KeyboardTyping, SmartphoneCall = false;


    public bool groupWalla_1, groupWalla_2, groupWalla_3, groupWalla_4, womenLaughing = false;

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

        if (groupWalla_1 == true) Play("Highschool Ambience");
        if (groupWalla_2 == true) Play("Highschool Ambience 2");
        if (groupWalla_3 == true) Play("Party Walla");
        if (groupWalla_4 == true) Play("Party Walla 2");
        if (womenLaughing == true) Play("Women Laughing");
    }

    public Sound Play (string name)
    {
        Sound s = Array.Find(sounds, s => s.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return null;
        }
        s.source.Play();

        return s;

    }

    IEnumerator PlayWait(Sound s)
    {
        s.source.Play();
        yield return new WaitWhile(() => s.source.isPlaying);
    }
}
