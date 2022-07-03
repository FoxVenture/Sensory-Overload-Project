using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    private int posX;
    private int posZ;

    //Saves a reference to the gameobject that gets placed on this cell
    public GameObject objectInThisCell = null;

    //Assigned card?
    public GameObject cardInThisCell = null;

    //Saves if the grid cell is occupied or not
    public bool isOccupied = false;

    //Set the position of this grid cell on the grid
    public void SetPosition(int x, int z)
    {
        posX = x;
        posZ = z;
    }

    //Get the position of this cell on the grid
    public Vector2Int GetPosition()
        { 
            return new Vector2Int(posX, posZ); 
        }
}
