using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelinePlayer : MonoBehaviour
{

    [SerializeField] bool Timeline_1, Timeline_2 = false; //, Timeline_3 = false;
    [SerializeField] PlayableDirector TimelineObj_1, TimelineObj_2; //, TimelineObj_3;

    public void StartTimeline(PlayableDirector director)
    {
        director.Play();
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
        /*
        if (Timeline_3 == true)
        {
            StartTimeline(TimelineObj_3);
            Timeline_3 = false;
        }
        */
    }
}
