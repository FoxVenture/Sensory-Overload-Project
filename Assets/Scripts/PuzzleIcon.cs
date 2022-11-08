using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleIcon : MonoBehaviour
{
    [SerializeField] Image image;
    public int matchCode;
    bool selected;

    public bool ClickIcon()
    {
        if (selected) selected = false;
        else if (!selected) selected = true;
        ChangeColour();
        return selected;
    }

    void ChangeColour()
    {
        if (selected) image.color = Color.blue;
        else if (!selected) image.color = Color.white;
    }
}
