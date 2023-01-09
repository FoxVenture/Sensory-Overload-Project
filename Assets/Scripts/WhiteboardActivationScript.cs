using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteboardActivationScript : MonoBehaviour
{
    [SerializeField] GameObject[] wDrawings;

    int wDrawingsCount = 0;

    void Start()
    {
        
    }

    private void GetAllDrawings()
    {
        foreach(GameObject g in wDrawings)
        { 
            Debug.Log("DRAWING ADDED: " + g.tag);
        }
    }
    public void NextDrawing()
    {
        wDrawings[wDrawingsCount].SetActive(true);
        wDrawingsCount++;
    }


}
