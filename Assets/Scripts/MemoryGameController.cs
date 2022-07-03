using System.Collections;
using Oculus.Interaction;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MemoryGameController : MonoBehaviour
{
    public static MemoryGameController Instance;
    //----------------------
    //public DebugScript debugger;
    //----------------------


    private GameObject[] selectedCards = new GameObject[2];
    private bool card_1_Selected, card_2_Selected = false;

    //Not using scriptable cards anymore
    //[SerializeField] private List<CardScriptable> cardDeck;

    [SerializeField] private GameGrid gameGrid;
    [SerializeField] private List<Material> cardsMaterial;

    void Start()
    {
        ClearArray();
        //cardsMaterial = deckScript.GetMaterials();
        //Debug.Log(cardsMaterial.Count);
        gameGrid.SetupMemoryGame(cardsMaterial, GetComponent<MemoryGameController>()/*, debugger*/);
    }
    private void Awake()
    {
        Instance = this;
    }

    // returns true if card placed in array
    public void NewCardSelected(GameObject card)
    {
        //debugger.AddItem("[3.0] Adding card to deck - MemoryGameController");
        //Debug.Log("[3.0] Adding card to deck - MemoryGameController");
        if (card_1_Selected == false && card_2_Selected == false)
        {
            //Debug.Log("[3.1.1] Adding card [0] - MemoryGameController");
            //debugger.AddItem("[3.1.1] Adding card [0] - MemoryGameController");
            selectedCards[0] = card;
            card_1_Selected = true;

        }
        else if (card_1_Selected == true && card_2_Selected == false)
        {
            //Debug.Log("[3.1.2] Adding card to [1] - MemoryGameController");
            //debugger.AddItem("[3.1.2] Adding card to [1] - MemoryGameController");
            selectedCards[1] = card;
            card_2_Selected = true;
            CompareCards();

        }
    }

    // Compares two selected cards
    private void CompareCards()
    {
        //Debug.Log("[4.0] Two selected, checking match - MemoryGameController");
        //debugger.AddItem("[4.0] Two selected, checking match - MemoryGameController");

        if (selectedCards[0].GetComponent<CardController>().key == selectedCards[1].GetComponent<CardController>().key)
        {
            //Debug.Log("[4.1.1] CARDS ARE A MATCH - MemoryGameController");
            //debugger.AddItem("[4.1.1] CARDS ARE A MATCH - MemoryGameController");
            MatchOutcome(MatchState.Match);
        }
        else
        {
            //Debug.Log("[4.1.2] CARDS ARE NOT A MATCH - MemoryGameController");
            //debugger.AddItem("[4.1.2] CARDS ARE NOT A MATCH - MemoryGameController");
            MatchOutcome(MatchState.NoMatch);
        }

    }

    private void MatchOutcome(MatchState outcome)
    {
        switch (outcome)
        {
            case MatchState.Match:
                StartCoroutine(CardMatchCoroutine());
                break;
            case MatchState.NoMatch:
                selectedCards[0].GetComponent<CardController>().DeselectCard();
                selectedCards[1].GetComponent<CardController>().DeselectCard();
                ClearSelection();
                break;
        }
    }


    private void ClearArray()
    {
        Array.Clear(selectedCards, 0, selectedCards.Length);
    }

    private void ClearSelection()
    {
        ClearArray();
        card_1_Selected = false;
        card_2_Selected = false;
    }

    IEnumerator CardMatchCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);

        selectedCards[0].gameObject.SetActive(false);
        selectedCards[1].gameObject.SetActive(false);
        ClearSelection();
    }

}


