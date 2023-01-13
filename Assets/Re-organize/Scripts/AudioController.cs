using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;


    void Start()
    {

    }

    public void Play()
    {
        audioSource.Play();
    }
}
