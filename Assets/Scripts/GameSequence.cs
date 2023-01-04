using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequence : MonoBehaviour
{
    [SerializeField] AudioManager audio;
    [SerializeField] bool audio1, audio2, audio3;
    private string[] audioNPCnames;
    public bool tabletlook;

    int audioNr = 0;
    int sequenceNr;

    private void Start()
    {
        audio1 = false;
        audio2 = false;
        audio3 = false;
        tabletlook = false;
        audioNPCnames = new string[] { "NPC_audio_1", "NPC_audio_2", "NPC_audio_3", "Chris_audio_1", "Chris_audio_2", "Chris_audio_3" };
        sequenceNr = 1;
        Sequence_Two();

    }
    private void Sequence_One()
    {
        //play timeline

    }

    private void Sequence_Two()
    {
        if (audioNr == 2)
        {
            playAudio(audioNPCnames[audioNr]);
            audioNr = 0;

        }
        else
        {
            playAudio(audioNPCnames[audioNr]);
            audioNr++;

        }

        StartCoroutine(WaitForRepeat());

    }
    public void TabletLookTrue()
    {
        tabletlook = true;
    }

    private void Sequence_Three()
    {
        if (audioNr == 5)
        {
            playAudio(audioNPCnames[audioNr]);
            audioNr = 3;

        }
        else
        {
            playAudio(audioNPCnames[audioNr]);
            audioNr++;

        }

        StartCoroutine(WaitForRepeat());
    }

    private void playAudio(string name)
    {
        audio.Play(name);
    }

    IEnumerator WaitForRepeat()
    {
        yield return new WaitForSeconds(5);
        if (!tabletlook)
        {
            Sequence_Two();
        }
        else
        {
            audioNr = 3;
            tabletlook = false;
            Sequence_Three();
        }
    }

}
