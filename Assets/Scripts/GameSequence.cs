using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequence : MonoBehaviour
{
    [SerializeField] AudioManager audio;
    [SerializeField] GameObject lookAtCollider, tabletLookAtColliger;

    private bool tabletlook;
    private string[] audioNPCnames;

    private void Start()
    {
        tabletlook = false;
        audioNPCnames = new string[] { "NPC_audio_1", "NPC_audio_2", "NPC_audio_3" };
    }
    private bool Sequence_One()
    {
        //play timeline

        //After timeline:
        lookAtCollider.active = true;
        tabletLookAtColliger.active = true;
        return true;
    }

        private bool Sequence_Two()
    {
        lookAtCollider.active = true;
        tabletLookAtColliger.active = true;
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

    public void LookCollission()
    {
        tabletlook = true;
        lookAtCollider.active = false;
        tabletLookAtColliger.active = false;
    }

    private void playAudio(string name)
    {
        audio.Play(name);
    }

    private void Update()
    {
        
    }

    IEnumerator WaitForRepeat()
    {
        yield return new WaitForSeconds(5);
    }
}
