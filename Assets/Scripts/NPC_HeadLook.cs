using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_HeadLook : MonoBehaviour
{
    //private NPC_StatePattern npcStatePattern;
    private Animator npcAnimator;
    [SerializeField] private GameObject head;

    public bool activateLookAt;

    void Start()
    {
        SetInitialReferences();
        activateLookAt = false;
    }

    void SetInitialReferences()
    {
        //npcStatePattern = GetComponent<NPC_StatePattern>();
        npcAnimator = GetComponent<Animator>();
    }

    private void OnAnimatorIK()
    {
        if (npcAnimator.enabled)
        {
            /*
            if(npcStatePattern.pursueTaget != null)
            {
            */
            if (activateLookAt)
            { 
                npcAnimator.SetLookAtWeight(1, 0, 0.5f, 0.5f, 0.7f);
                npcAnimator.SetLookAtPosition(head.transform.position);
            }
            else
            {
                npcAnimator.SetLookAtWeight(0);
            }

            if (!activateLookAt)
            {
                npcAnimator.SetLookAtWeight(0);
            }
        }
    }

}
