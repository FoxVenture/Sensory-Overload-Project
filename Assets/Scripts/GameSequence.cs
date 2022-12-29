using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequence : MonoBehaviour
{
    [SerializeField] AudioManager audio;

    [SerializeField] bool tabletlook;
    [SerializeField] bool audio1, audio2, audio3;
    [SerializeField] int audioNr=0;
    private string[] audioNPCnames;

    int sequenceNr;

    private void Start()
    {
        audio1 = false;
        audio2 = false;
        audio3 = false;
        tabletlook = false;
        audioNPCnames = new string[] { "NPC_audio_1", "NPC_audio_2", "NPC_audio_3" };
        sequenceNr = 1;
        //Sequence_Two();

    }
    private bool Sequence_One()
    {
        //play timeline

        return true;
    }

    private bool Sequence_Two()
    {
       
        //ADD WAIT X SECONDS
        int audioNr = 0;

        while(!tabletlook)
        {
            if(audioNr == 2)
            {
                playAudio(audioNPCnames[audioNr]);
                audioNr = 0;
            }
            else
            {
                playAudio(audioNPCnames[audioNr]);
                audioNr++;
            }
            WaitForRepeat();
        }

        return false;
    }

    private void Update()
    {
        if (tabletlook == true)
        {
            tabletlook = false;
            playAudio(audioNPCnames[audioNr]);
            audioNr++;
        }
    }


    private void playAudio(string name)
    {
        PlayWait(audio.Play(name));
        Debug.Log("TESTING: YAAAY IT WAITED");
    }

    IEnumerator WaitForRepeat()
    {
        yield return new WaitForSeconds(5);
    }

    IEnumerator PlayWait(Sound s)
    {
        Debug.Log("TESTING: coroutine start");
        yield return new WaitWhile(() => s.source.isPlaying);
        Debug.Log("TESTING: coroutine done");
    }
}
