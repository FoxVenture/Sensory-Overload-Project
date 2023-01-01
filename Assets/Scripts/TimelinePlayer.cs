using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelinePlayer : MonoBehaviour
{

    [SerializeField] bool Timeline_1, Timeline_2 = false, Timeline_3 = false;
    [SerializeField] bool groupWalla_1, groupWalla_2, groupWalla_3, groupWalla_4, groupWalla_5 = false;

    [SerializeField] PlayableDirector TimelineObj_1, TimelineObj_2, TimelineObj_3;
    [SerializeField] GameObject aClip1, aClip2, aClip3, aClip4, aClip5;

    public void StartTimeline(PlayableDirector director)
    {
        director.Play();
    }

    private void Start()
    {
        aClip1.active = false;
        aClip2.active = false;
        aClip3.active = false;
        aClip4.active = false; 
        aClip5.active = false;
    }

    private void Update()
    {
        if (Timeline_1 == true)
        {
            StartTimeline(TimelineObj_1);
            Timeline_1 = false;
        }

        if (Timeline_2 == true)
        {
            StartTimeline(TimelineObj_2);
            Timeline_2 = false;
        }
        
        if (Timeline_3 == true)
        {
            StartTimeline(TimelineObj_3);
            Timeline_3 = false;
        }

        if (groupWalla_1 == true)
        {
            aClip1.active = true;
        }
        if (groupWalla_1 == false)
        {
           aClip1.active = false;
        }

        if (groupWalla_2 == true)
        {
            aClip2.active = true;
        }
        if (groupWalla_2 == false)
        {
            aClip2.active = false;
        }

        if (groupWalla_3 == true)
        {
            aClip3.active = true;
        }
        if (groupWalla_3 == false)
        {
            aClip3.active = false;
        }

        if (groupWalla_4 == true)
        {
            aClip4.active = true;
        }
        if (groupWalla_4 == false)
        {
            aClip4.active = false;
        }

        if (groupWalla_5 == true)
        {
            aClip5.active = true;
        }
        if (groupWalla_5 == false)
        {
            aClip5.active = false;
        }
    }
}
