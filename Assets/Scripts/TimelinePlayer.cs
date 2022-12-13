using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelinePlayer : MonoBehaviour
{
    /*
    private PlayableDirector director;
    public GameObject controlPanel;
    */

    [SerializeField] bool Timeline_1, Timeline_2, Timeline_3 = false;
    [SerializeField] PlayableDirector TimelineObj_1, TimelineObj_2, TimelineObj_3;

    /*
    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
        director.played += Director_Played;
        director.stopped += Director_Stopped;
    }
    private void Director_Stopped(PlayableDirector obj)
    {
        controlPanel.SetActive(true);
    }

    private void Director_Played(PlayableDirector obj)
    {
        controlPanel.SetActive(false);
    }
    */

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

        if (Timeline_3 == true)
        {
            StartTimeline(TimelineObj_3);
            Timeline_3 = false;
        }
    }
}
