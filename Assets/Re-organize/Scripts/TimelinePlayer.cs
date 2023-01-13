using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelinePlayer : MonoBehaviour
{
    public void StartTimeline(PlayableDirector director)
    {
        director.Play();
    }

    
    public void PlayTimeline(PlayableDirector p)
    {
        StartTimeline(p);
    }

    public void PlayTimeline(GameObject p)
    {
        StartTimeline(p.GetComponent<PlayableDirector>());
    }
}
