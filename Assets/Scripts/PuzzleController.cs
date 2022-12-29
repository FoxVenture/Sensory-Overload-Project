using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    List<PuzzleIcon> selectedList;
    int listCount;
    // Start is called before the first frame update
    void Start()
    {
        selectedList = new List<PuzzleIcon>();
    }

    public void OnClick(PuzzleIcon clicked)
    {
        if (clicked.ClickIcon())
        {
            selectedList.Add(clicked);
            listCount++;
        }
        else
        {
            selectedList.Remove(clicked);
            listCount--;
        }
        ListCountCheck();
    }

    void ListCountCheck()
    {
        if(listCount == 3)
        {
            int match = 0;
            int firstCode = 0;
            foreach(PuzzleIcon p in selectedList)
            {
                if (firstCode != 0)
                {
                    if (p.matchCode == firstCode) match++;
                }
                else firstCode = p.matchCode;
            }

            if (match == 2) IconsMatched();
            else IconsReset();
        }
    }

    void IconsMatched()
    {
        foreach(PuzzleIcon p in selectedList)
        {
            p.GetComponent<GameObject>().SetActive(false);
            ClearList();
        }
    }

    void IconsReset()
    {
        foreach(PuzzleIcon p in selectedList)
        {
            p.ClickIcon();
            ClearList();
        }
    }

    void ClearList()
    {
        foreach (PuzzleIcon p in selectedList)
        {
            selectedList.Remove(p);
        }
    }
}
