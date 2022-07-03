using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SensoryManager : MonoBehaviour
{
    public GameObject[] disturbanceObjects;

    public bool smartphone = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (smartphone) PlayAudioAnimation("Smartphone", "PhoneVibrate", "Vibrate");
    }

    private void PlayAudioAnimation(string objectName,  string audioName, string animationTrigger)
    {
        foreach(GameObject g in disturbanceObjects)
        {
            if(g.name == objectName)
            {
                g.GetComponent<AnimationController>().Trigger(animationTrigger);
                g.GetComponent<AudioController>().Play();
            }
        }
    }

    private void PlayAudio(string name)
    {

    }

    private void PlayAnimation(string trigger)
    {

    }
}
