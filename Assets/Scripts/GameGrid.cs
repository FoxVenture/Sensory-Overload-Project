using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    [SerializeField]private int length = 4;
    [SerializeField]private int width = 4;
    private float GridSpaceSize = 0.1f;

    [SerializeField] private GameObject gridCellPrefab, cardPrefab;
    [SerializeField] private Transform parentPos;

    [Tooltip("Add the materials for the cards you want in the game. Each material will create two cards (pair).")]
    [SerializeField] private List<Material> cardMaterials;

    private GameObject[,] gameGrid;
    private List<GameObject> cardDeck;

    void Start()
    {
        cardDeck = new List<GameObject>();
    }

    public void SetupMemoryGame(List<Material> cDeck, MemoryGameController mController/*, DebugScript debugger*/)
    {
        cardMaterials = cDeck;

        transform.localPosition = new Vector3(0, 0, 0);

        CreateCards(mController);
        CreateGrid();
    }


    private void CreateGrid()
    {
        gameGrid = new GameObject[length, width];
        List<GameObject> tempDeck = cardDeck;

        if (gridCellPrefab == null)
        {
            Debug.LogError("ERROR: Grid Cell Prefab on the game grid is not assigned");
            return;
        }

        for (int z = 0; z < length; z++)
        {
            for (int x = 0; x < width; x++)
            {

                // Create a new 'GridSpace' object for each cell
                Vector3 newPosition = new Vector3(x * GridSpaceSize, 0, z * GridSpaceSize);
                gameGrid[x, z] = Instantiate(gridCellPrefab, new Vector3(newPosition.x + parentPos.position.x, newPosition.y + parentPos.position.y, newPosition.z + parentPos.position.z), Quaternion.identity);
                // Everything it spawns will be spawned as a child under game grid. 
                gameGrid[x, z].transform.parent = transform;
                gameGrid[x, z].gameObject.name = "Grid Space ( X: " + x.ToString() + " Z: " + z.ToString() + ")";

                // Add random card from deck
                if (tempDeck.Count != 0)
                {
                    int rand = GetRandom(tempDeck.Count);
                    Debug.Log("Random nr: " + rand);

                    tempDeck[rand].transform.parent = gameGrid[x, z].transform;
                    tempDeck[rand].transform.localPosition = Vector3.zero;
                    tempDeck.Remove(tempDeck[rand]);
                }

            }
        }
    }

    /*
     * CREATED FROM MATERIAL LIST
     */
    private void CreateCards(MemoryGameController mController)
    {
        GameObject newCard;

        int keyNr = 1;
        int tempCount = 0;


        foreach (Material m in cardMaterials)
        {
            //Create two cards per material in the list
            for (int i = 0; i < 2; i++)
            {
                // Instantiate card
                newCard = Instantiate(cardPrefab);
                // Get all materials of card
                Material[] mats = newCard.GetComponentInChildren<Renderer>().materials;
                // Replace prefab front with new material
                mats[1] = m;
                newCard.GetComponentInChildren<Renderer>().materials = mats;

                // Set card key
                newCard.GetComponent<CardController>().key = keyNr;
                newCard.GetComponent<CardController>().SetGameController(mController);
                //newCard.GetComponent<CardController>().debugger = debugger;
                //newCard.GetComponent<TriggerScript>().debugger = debugger;

                cardDeck.Add(newCard);

                tempCount++;
                //Debug.Log("Cards made: " + tempCount);
            }
            keyNr++;
        }
    }

    /*
     * CREATED FROM SCRIPTABLE OBJECT
     * 
    private void CreateCards()
    {
        GameObject newCard;
        int tempCount = 0;

        foreach (CardScriptable s in scriptables)
        {
            for (int i = 0; i < 2; i++)
            {
                newCard = Instantiate(cardPrefab);
                Material[] m = newCard.GetComponentInChildren<Renderer>().materials;
                m[1] = s.front;
                newCard.GetComponentInChildren<Renderer>().materials = m;
                cardDeck.Add(newCard);

                tempCount++;
                Debug.Log("Cards made: " + tempCount);
            }
        }
    }
    */

    private void AssignRandomCard()
    {

    }

    private void PlaceCardsOnGrid()
    {
        
    }

    private int GetRandom(int count)
    {
        int rand = Random.Range(0, count);
        return rand;
    }

}
