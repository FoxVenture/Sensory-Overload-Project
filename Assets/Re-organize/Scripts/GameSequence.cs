using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequence : MonoBehaviour
{
    [SerializeField] AudioManager audio;
    [SerializeField] bool audio1, audio2, audio3;
    [SerializeField] GameObject NPC;
    Animator animator;
    private string[] audioTabletLook;
    private string[] audioEmailLook;
    public bool interacted;

    int audioNr = 0;
    int sequenceNr;

    private void Start()
    {
        animator = NPC.GetComponent<Animator>();
        audio1 = false;
        audio2 = false;
        audio3 = false;
        interacted = false;
        audioTabletLook = new string[] { "NPC_audio_1", "NPC_audio_2", "NPC_audio_3" };
        audioEmailLook = new string[] { "Chris_audio_1", "Chris_audio_2" };
        sequenceNr = 1;

    }
    //Timeline 1
    private void Sequence_One()
    {
    }

    //Audio Classmate look at tablet
    private void PlaySequence_Two()
    {
        if (audioNr == 2)
        {
            animator.SetTrigger("HardNod");
            playAudio(audioTabletLook[audioNr]);
            audioNr = 0;

        }
        else
        {
            animator.SetTrigger("HardNod");
            playAudio(audioTabletLook[audioNr]);
            audioNr++;

        }

        StartCoroutine(WaitForRepeat());

    }

    //Audio Player check Email
    private void PlaySequence_Three()
    { /*
        if (audioNr == 1)
        {
            playAudio(audioEmailLook[audioNr]);
            audioNr = 0;

        }
        else
        {
            playAudio(audioEmailLook[audioNr]);
            audioNr++;

        }

        StartCoroutine(WaitForRepeat());
        */
    }

    public void InteractedTrue()
    {
        interacted = true;
    }

    private void playAudio(string name)
    {
        audio.Play(name);
    }
    public void PlaySequence()
    {
        if(sequenceNr == 0)
        {
            sequenceNr++;
            StartCoroutine(WaitForRepeat());
        }
        if(sequenceNr == 1)
        {
            PlaySequence_Two();
        }
        if(sequenceNr == 2)
        {
            PlaySequence_Three();
        }
        if(sequenceNr==3)
        { }
    }

    IEnumerator WaitForRepeat()
    {
        yield return new WaitForSeconds(10);
        if (!interacted)
        {
            PlaySequence();
        }
        else
        {
            interacted = false;
            sequenceNr++;
            PlaySequence();
        }
    }

}
