using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    //----------------------
   // public DebugScript debugger;
    //----------------------

    public int key { get; set; }
    [SerializeField]
    private AnimationController animation;
    private TriggerScript cardTrigger;
    [SerializeField]
    private GameObject thisCard;
    MemoryGameController memoryGameController;

    private bool selected;

    void Start()
    {
        selected = false;
        cardTrigger = gameObject.GetComponent<TriggerScript>();
    }

    void Update()
    {
        if(cardTrigger.isTriggered && !selected)
        {
            selected = true;
            //Debug.Log("[2.1] Selecting Card now - CardController");
            //debugger.AddItem("[2.1] Selecting Card now - CardController");
            memoryGameController.NewCardSelected(thisCard);
            animation.Trigger("Flip Up");
        }
    }

    
    public void SetGameController(MemoryGameController mController)
    {
        memoryGameController = mController;
    }
    

    public void DeselectCard()
    {
        animation.Trigger("Flip Down");
        cardTrigger.isTriggered = false;
        selected = false;
    }

}

