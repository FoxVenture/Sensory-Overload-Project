using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject tL_1, tL_2;
    TimelinePlayer tPlayer;
    AudioManager audioManager;
    
    public bool buttonClick_1, buttonClick_2;

    void Start()
    {
        Debug.Log("MANAGER STARTED");
        tPlayer = GetComponent<TimelinePlayer>();
        audioManager = GetComponent<AudioManager>();
        PlayTimeline(tL_1);
    }

    private void Update()
    {
        /*
        if(buttonClick_1 == true)
        { 
            buttonClick_1 = false;
            PlayAudio(1);
        }

        if(buttonClick_2 == true)
        {
            buttonClick_2 = false;
            PlayTimeline(tL_2);
        }
        */
    }

    public void PlayTimeline(GameObject i)
    {
        tPlayer.PlayTimeline(i);

    }

    public void PlayAudio(int nr)
    {
        StartCoroutine(WaitForAudioPlay(nr));
    }


    IEnumerator WaitForAudioPlay(int i)
    {
        yield return new WaitForSeconds(2);
        audioManager.Play(i);        
    }
}
