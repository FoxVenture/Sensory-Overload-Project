using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class TriggerScript : MonoBehaviour
{
    //----------------------
    //public DebugScript debugger;
    //----------------------
    public bool isTriggered;

    [SerializeField, Interface(typeof(IInteractableView))]
    private MonoBehaviour _interactableView;

    private IInteractableView InteractableView;

    protected bool _started = false;

    protected virtual void Awake()
    {
        InteractableView = _interactableView as IInteractableView;
    }

    protected virtual void Start()
    {
        isTriggered = false;
        this.BeginStart(ref _started);
        Assert.IsNotNull(InteractableView);

        this.EndStart(ref _started);
    }

    
    protected virtual void OnEnable()
    {
        if (!isTriggered)
        {
            if (_started)
            {
                InteractableView.WhenStateChanged += UpdateVisualState;
            }
        }
    }

    protected virtual void OnDisable()
    {
        if (_started)
        {
            InteractableView.WhenStateChanged -= UpdateVisualState;
        }
    }
    
    public InteractableState GetState()
    {
        return InteractableView.State;
    }

    
    private void UpdateVisual()
    {
        switch (InteractableView.State)
        {
            case InteractableState.Normal: // Not bein touched
                //Debug.Log("[1.1] card is NORMAL");
                //debugger.AddItem("[1.1] card is NORMAL");
                break;
            case InteractableState.Hover: // In trigger area
                //Debug.Log("[1.2] card is HOVER");
                //debugger.AddItem("[1.2] card is HOVER");
                break;
            case InteractableState.Select: // Touched far enough to trigger
                //Debug.Log("[1.3] card is SELECT");
                //debugger.AddItem("[1.3] card is SELECT");
                SelectTriggered();
                break;
            case InteractableState.Disabled:
                //Debug.Log("card is GONE");
                break;
        }
    }

    private void SelectTriggered()
    {
        if (!isTriggered)
        {
            isTriggered = true;
            //Debug.Log("[1.3.1] card is selected - TriggerScript");
            //debugger.AddItem("[1.3.1] card is selected - TriggerScript");
        }
    }
  
    private void UpdateVisualState(InteractableStateChangeArgs args) => UpdateVisual();

    #region Inject
     
    #endregion 
}

